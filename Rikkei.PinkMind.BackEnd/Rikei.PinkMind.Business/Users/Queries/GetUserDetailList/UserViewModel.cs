using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetailList
{
  public class UserViewModel
  {
      public IEnumerable<UserDTO> users { get; set; }
  }
}
