using MediatR;

namespace Rikei.PinkMind.Business.TeamDetails.Queries.GetAllTeamDetail
{
  public class GetAllTeamDetailsQuery : IRequest<TeamDetailsViewModel>
  {
    public int ID { get; set; }
  }
}
