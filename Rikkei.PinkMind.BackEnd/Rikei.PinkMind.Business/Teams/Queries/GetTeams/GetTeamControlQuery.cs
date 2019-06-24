using MediatR;

namespace Rikei.PinkMind.Business.Teams.Queries.GetTeams
{
  public class GetTeamControlQuery : IRequest<GetTeamModel>
  {
    public int ID { get; set; }
  }
}
