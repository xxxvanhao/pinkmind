using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Teams.Commands.Create
{
  public class CreateTeamCommands : IRequest<int>
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool DelFlag { get; set; }
    public class Handler : IRequestHandler<CreateTeamCommands, int>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<int> Handle(CreateTeamCommands request, CancellationToken cancellationToken)
      {
        var entity = new Team
        {
          Name = request.Name,
          CreateAt = DateTime.Now,
          CreateBy = request.CreateBy,
          LastUpdate = DateTime.Now,
          UpdateBy = request.UpdateBy,
          DelFlag = true
        };
        _pmContext.Teams.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return entity.ID;
      }

    }
  }
}
