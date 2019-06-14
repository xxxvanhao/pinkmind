using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetail
{
  public class UserDetailModel
  {
    public int ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PictureUrl { get; set; }
    public string SpaceID { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }

    public static Expression<Func<User, UserDetailModel>> Projection
    {
      get
      {
        return user => new UserDetailModel
        {
          ID = user.ID,
          Email = user.Email,
          Password = user.Password,
          LastName = user.LastName,
          FirstName = user.FirstName,
          PictureUrl = user.PictureUrl,
          SpaceID = user.SpaceID,
          CreateAt = user.CreateAt,
          LastUpdate = user.LastUpdate
        };
      }
    }
    public static UserDetailModel Create(User user)
    {
      return Projection.Compile().Invoke(user);
    }
  }
}
