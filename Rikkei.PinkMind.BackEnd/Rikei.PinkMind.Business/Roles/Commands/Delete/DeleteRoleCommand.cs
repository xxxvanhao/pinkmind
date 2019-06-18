using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Roles.Commands.Delete
{
    public class DeleteRoleCommand : IRequest
    {
      public int ID { get; set; }
    }
}
