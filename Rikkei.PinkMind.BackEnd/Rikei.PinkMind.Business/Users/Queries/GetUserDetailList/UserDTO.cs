using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetailList
{
  public class UserDTO 
  {
    public long ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PictureUrl { get; set; }
    public string SpaceID { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime LastUpdate { get; set; }
    public string FullName
    {
      get
      {
        return FirstName + " " + LastName;
      }
    }
  }
}
