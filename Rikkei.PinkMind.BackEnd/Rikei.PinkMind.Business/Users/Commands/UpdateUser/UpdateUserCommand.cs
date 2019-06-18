using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Users.Commands.UpdateUser
{
  public class UpdateUserCommand : IRequest
  {
    public long ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PictureUrl { get; set; }
    public string SpaceID { get; set; }

    public class Handler : IRequestHandler<UpdateUserCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
      {
        var entity = await _pmContext.Users.SingleOrDefaultAsync(u => u.ID == request.ID);
        if(entity == null)
        {
          throw new NotFoundException(nameof(User), request.ID);
        }

        entity.Password = request.Password ?? entity.Password;
        entity.LastName = request.LastName ?? entity.LastName;
        entity.FirstName = request.FirstName ?? entity.FirstName;
        entity.PictureUrl = request.PictureUrl ?? entity.PictureUrl;
        entity.SpaceID = request.SpaceID ?? entity.SpaceID;
        entity.LastUpdate = DateTime.UtcNow;
        await _pmContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
