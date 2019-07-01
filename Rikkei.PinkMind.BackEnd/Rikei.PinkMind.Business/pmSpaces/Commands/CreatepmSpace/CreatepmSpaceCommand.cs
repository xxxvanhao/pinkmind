using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.CreatepmSpace
{
  public class CreatepmSpaceCommand : IRequest
  {
    public string SpaceID { get; set; }
    public string OrganizationName { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }

    public class Handler : IRequestHandler<CreatepmSpaceCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreatepmSpaceCommand request, CancellationToken cancellationToken)
      {
        var eSpace = new Space
        {
          SpaceID = request.SpaceID,
          OrganizationName = request.OrganizationName,
          CreateBy = request.CreateBy,
          CreateAt = DateTime.Now,
          UpdateBy = request.UpdateBy,
          LastUpdate = DateTime.Now,
          DelFlag = true
        };
        _pmContext.Spaces.Add(eSpace);
        await _pmContext.SaveChangesAsync();

        var eSpaceControl = new SpaceControl
        {
          SpaceID = request.SpaceID,
          ControlBy = request.CreateBy
        };
        _pmContext.SpaceControls.Add(eSpaceControl);
        await _pmContext.SaveChangesAsync();

        var eUser = await _pmContext.Users.FindAsync(request.CreateBy);
        eUser.SpaceID = request.SpaceID;
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }

    }
  }
}
