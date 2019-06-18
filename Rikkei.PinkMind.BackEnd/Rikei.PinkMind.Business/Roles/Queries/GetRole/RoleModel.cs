using MediatR;
using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rikei.PinkMind.Business.Roles.Queries.GetRole
{
  public class RoleModel : IRequest
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public static Expression<Func<Role, RoleModel>> Projection
    {
      get
      {
        return role => new RoleModel
        {
          ID = role.ID,
          Name = role.Name
        };
      }
    }
    public static RoleModel Create(Role role)
    {
      return Projection.Compile().Invoke(role);
    }
  }
}
