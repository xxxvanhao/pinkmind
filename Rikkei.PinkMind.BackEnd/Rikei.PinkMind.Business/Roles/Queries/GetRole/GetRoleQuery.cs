using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Roles.Queries.GetRole
{
    public class GetRoleQuery : IRequest<RoleModel>
    {
    public int ID { get; set; }
    }
}
