using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Queries.GetUserDetail
{
  public class GetUserDetailQuery : IRequest<UserDetailModel>
  {
     public long ID { get; set; }
  }
}
