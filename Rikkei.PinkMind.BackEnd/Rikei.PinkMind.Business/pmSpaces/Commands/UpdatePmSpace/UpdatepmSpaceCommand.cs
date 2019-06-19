using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.UpdatePmSpace
{
  public class UpdatepmSpaceCommand : IRequest
  {
    public string SpaceID { get; set; }
    public string OrganizationName { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public string CheckUpdate { get; set; }

    public class Handler : IRequestHandler<UpdatepmSpaceCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }

      public async Task<Unit> Handle(UpdatepmSpaceCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Spaces.SingleOrDefaultAsync(u => u.SpaceID == request.SpaceID);
        if (entity == null)
        {
          throw new NotFoundException(nameof(Space), request.SpaceID);
        }
        entity.OrganizationName = request.OrganizationName ?? entity.OrganizationName;
        entity.CreateAt = DateTime.UtcNow;
        entity.UpdateBy = request.UpdateBy;
        entity.LastUpdate = DateTime.UtcNow;
        entity.DelFlag = !request.DelFlag ? true: false;
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }

  }
}
