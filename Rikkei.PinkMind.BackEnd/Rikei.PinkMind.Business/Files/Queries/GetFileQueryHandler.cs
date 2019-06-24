using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Files.Queries
{
  public class GetFileQueryHandler : IRequestHandler<GetFileQuery, FileModel>
  {

    private readonly PinkMindContext _pmContext;
    public GetFileQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<FileModel> Handle(GetFileQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Files.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(File), request.ID);
      }

      return FileModel.Create(entity);
    }
  }
}
