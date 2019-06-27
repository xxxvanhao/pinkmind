using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetailList
{
  public class UserQuery : IRequest<UserViewModel>
  {
    public long userID { get; set; }
  }
}
