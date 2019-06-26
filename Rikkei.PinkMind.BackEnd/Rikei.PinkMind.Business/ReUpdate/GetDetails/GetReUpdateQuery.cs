using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.ReUpdate.GetDetails
{
  public class GetReUpdateQuery : IRequest<ReUpdateViewModel>
  {
    public string projectKey { get; set; }
    public long userID { get; set; }
  }
}
