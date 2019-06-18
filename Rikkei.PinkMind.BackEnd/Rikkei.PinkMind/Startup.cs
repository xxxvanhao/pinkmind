using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Rikkei.PindMind.DAO.Auth;
using Rikkei.PindMind.DAO;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Rikkei.PindMind.DAO.Helper;
using Rikkei.PindMind.DAO.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using FluentValidation.AspNetCore;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Rikkei.PindMind.DAO.Extensions;
using Rikei.PinkMind.Business.Implementation;
using MediatR;
using Rikei.PinkMind.Business.Users.Queries.GetUserDetail;
using System.Reflection;
using Rikei.PinkMind.Business.Users.Commands.CreateUser;
using Rikei.PinkMind.Business.Users.Commands.UpdateUser;
using Rikei.PinkMind.Business.Users.Commands.DeleteUser;
using Rikei.PinkMind.Business.SpaceControls.Commands.UpdatePmSpaceControls;

namespace Rikkei.PinkMind
{
  public class Startup
  {
    private const string SecretKey = "42e28fa05114cef1a4517c69c53884cf"; // todo: get this from somewhere secure
    private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddDbContext<PinkMindContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("PinkMindContext"),
              b => b.MigrationsAssembly("Rikkei.PinkMind.Migrator")));
      services.AddSingleton<IJwtFactory, JwtFactory>();

      // Register the ConfigurationBuilder instance of FacebookAuthSettings
      services.Configure<FacebookAuthSettings>(Configuration.GetSection(nameof(FacebookAuthSettings)));

      services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
      services.AddTransient<IssueReponsetory>();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      // jwt wire up
      // Get options from app settings
      var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

      // Configure JwtIssuerOptions
      services.Configure<JwtIssuerOptions>(options =>
      {
        options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
        options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
      });

      var tokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

        ValidateAudience = true,
        ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = _signingKey,

        RequireExpirationTime = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
      };

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

      }).AddJwtBearer(configureOptions =>
      {
        configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
        configureOptions.TokenValidationParameters = tokenValidationParameters;
        configureOptions.SaveToken = true;
      });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("ApiUser", policy => policy.RequireClaim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
      });

      services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
      services.AddCors();

      //AddMediatR

      services.AddMediatR(typeof(GetUserDetailQueryHandler).GetTypeInfo().Assembly,
                          typeof(CreateUserCommand.Handler).GetTypeInfo().Assembly,
                          typeof(UpdateUserCommand.Handler).GetTypeInfo().Assembly,
                          typeof(DeleteUserQueryHandler).GetTypeInfo().Assembly,
                          typeof(UpdatepmSpaceControlCommand.Handler).GetTypeInfo().Assembly);      
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseExceptionHandler(
       builder =>
      {
        builder.Run(
                         async context =>
                      {
                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                 context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                 var error = context.Features.Get<IExceptionHandlerFeature>();
                 if (error != null)
                 {
                   context.Response.AddApplicationError(error.Error.Message);
                   await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                 }
               });
      });
      app.UseCors(
          options => options.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());

      app.UseAuthentication();
      app.UseDefaultFiles();
      app.UseStaticFiles();
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
