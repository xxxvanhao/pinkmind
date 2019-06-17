using MediatR;
using Rikei.PinkMind.Business.Users.Commands.CreateUser;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Rikei.PinkMind.Business.Users.Commands.CreateUser.CreateUserCommand;

namespace Rikei.PinkMind.Business.pmSpaces.Commands.CreatepmSpace
{
  class CreatepmSpaceCommand : IRequest
  {
    public string SpaceID { get; set; }
    public string OrganizationName { get; set; }
    public int CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public int UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }

    public class Handler : IRequestHandler<CreatepmSpaceCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreatepmSpaceCommand request, CancellationToken cancellationToken)
      {
        var entity = new Space
        {
          SpaceID = request.SpaceID,
          OrganizationName = request.OrganizationName,
          CreateBy = request.CreateBy,
          CreateAt = request.CreateAt,
          UpdateBy = request.UpdateBy,
          LastUpdate = request.LastUpdate

        };
        _pmContext.Spaces.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
      
    }
  }
}
