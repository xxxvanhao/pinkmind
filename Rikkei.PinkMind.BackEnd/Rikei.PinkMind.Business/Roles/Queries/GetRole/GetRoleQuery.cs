using MediatR;

namespace Rikei.PinkMind.Business.Roles.Queries.GetRole
{
  public class GetRoleQuery : IRequest<RoleModel>
    {
    public int ID { get; set; }
    }
}
