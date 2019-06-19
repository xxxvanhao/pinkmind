using MediatR;
using Rikei.PinkMind.Business.Exceptions;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Comments.Queries
{
  class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, CommentModel>
  {
    private readonly PinkMindContext _pmContext;
    public GetCommentQueryHandler(PinkMindContext pinkMindContext)
    {
      _pmContext = pinkMindContext;
    }
    public async Task<CommentModel> Handle(GetCommentQuery request, CancellationToken cancellationToken)
    {
      var entity = await _pmContext.Comments.FindAsync(request.ID);

      if (entity == null)
      {
        throw new NotFoundException(nameof(Comment), request.ID);
      }

      return CommentModel.Create(entity);
    }
  }
}
