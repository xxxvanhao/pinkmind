using MediatR;
using Rikei.PinkMind.Business.Comments.Comments.GetAllComment;

namespace Rikei.PinkMind.Business.Comments.Queries.GetAllComment
{
  public class GetAllTeamDetailsQuery : IRequest<CommentsViewModel>
  {
    public int ID { get; set; }
  }
}
