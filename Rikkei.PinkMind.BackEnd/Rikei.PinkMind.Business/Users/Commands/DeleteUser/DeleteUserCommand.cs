using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Users.Commands.DeleteUser
{
  public class DeleteUserCommand : IRequest
  {
    public long ID { get; set; }
  }
}
