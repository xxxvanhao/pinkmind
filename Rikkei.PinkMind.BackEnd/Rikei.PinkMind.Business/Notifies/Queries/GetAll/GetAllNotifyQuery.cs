using MediatR;
using Rikei.PinkMind.Business.Priorities.Queries.GetAllPriority;

namespace Rikei.PinkMind.Business.Notifies.Queries.GetAll
{
  public class GetAllNotifyQuery : IRequest<NotifyViewModel>
  {
    public long userID { get; set; }
  }
}
