using MediatR;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail
{
  public class GetAllTeamDetailsQuery : IRequest<TeamDetailsViewModel>
  {
    public string TeamName { get; set; }
  }
}
