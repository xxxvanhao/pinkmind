using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rikkei.PindMind.DAO;
using Rikkei.PindMind.DAO.Auth;
using Rikkei.PindMind.DAO.Helper;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;

namespace Rikkei.PinkMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PinkMindContext _pmDbContext;
        private readonly FacebookAuthSettings _fbAuthSettings;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private static readonly HttpClient Client = new HttpClient();
        public AuthController(IOptions<FacebookAuthSettings> fbAuthSettingsAccessor, PinkMindContext pmDbContext, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _fbAuthSettings = fbAuthSettingsAccessor.Value;
            _pmDbContext = pmDbContext;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        // POST api/auth/facebook
        [HttpPost("facebook")]
        public async Task<IActionResult> Facebook([FromBody]FacebookAuthViewModel model)
        {
            // 1.generate an app access token
            var appAccessTokenResponse = await Client.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_fbAuthSettings.AppId}&client_secret={_fbAuthSettings.AppSecret}&grant_type=client_credentials");
            var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
            // 2. validate the user access token
            var userAccessTokenValidationResponse = await Client.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={model.AccessToken}&access_token={appAccessToken.AccessToken}");
            var userAccessTokenValidation = JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

            if (!userAccessTokenValidation.Data.IsValid)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Invalid facebook token.", ModelState));
            }

            // 3. we've got a valid token so we can request user data from fb
            var userInfoResponse = await Client.GetStringAsync($"https://graph.facebook.com/v3.2/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={model.AccessToken}");
            var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

      // 4. ready to create the local user account (if necessary) and jwt
      var user = await _pmDbContext.User.FindAsync(userInfo.Id);
      if (user == null)
             {
                var appUser = new User
                {
                    ID = (int)userInfo.Id,
                    FirstName = userInfo.FirstName,
                    LastName = userInfo.LastName,
                    Email = userInfo.Email,
                    PictureUrl = userInfo.Picture.Data.Url,
                    CreateAt = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow
                };

                await _pmDbContext.User.AddAsync(appUser);
                await _pmDbContext.SaveChangesAsync();
            }

            // generate the jwt for the local user...
            var localUser = await _pmDbContext.User.FindAsync(userInfo.Id);
            
            if (localUser == null)
            {
                return BadRequest(Errors.AddErrorToModelState("login_failure", "Failed to create local user account.", ModelState));
            }

            var jwt = await Tokens.GenerateJwt(_jwtFactory.GenerateClaimsIdentity(localUser.Email, localUser.ID.ToString()),
              _jwtFactory, localUser.Email, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });

            return new OkObjectResult(jwt);
        }
    }
}
