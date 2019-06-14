using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Users.Commands.CreateUser
{
  public class CreateUserCommand : IRequest
  {
    public int ID { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PictureUrl { get; set; }
    public string SpaceID { get; set; }

    public class Handler : IRequestHandler<CreateUserCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
      {
        var entity = new User
        {
          ID = request.ID,
          Email = request.Email,
          Password = request.Password,
          LastName = request.LastName,
          FirstName = request.FirstName,
          PictureUrl = request.PictureUrl,
          SpaceID = request.SpaceID,
          CreateAt = DateTime.UtcNow,
          LastUpdate = DateTime.UtcNow
        };
        _pmContext.Users.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
