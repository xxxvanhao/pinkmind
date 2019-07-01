using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.ProjectFile.GetAllFolder
{
  public class GetAllFileQueryHandler : IRequestHandler<GetAllFileQuery, FileViewModel>
  {
    private readonly PinkMindContext _pmContext;
    private readonly IMapper _mapper;

    public GetAllFileQueryHandler(PinkMindContext pinkMindContext, IMapper mapper)
    {
      _pmContext = pinkMindContext;
      _mapper = mapper;
    }

    public async Task<FileViewModel> Handle(GetAllFileQuery request, CancellationToken cancellationToken)
    {
      var file = _pmContext.ProjectFiles.Where( pf => pf.FolderPath == request.path);
      var fileDetails = await file.ToListAsync(cancellationToken);

      var model = new FileViewModel
      {
        FileDTOs = _mapper.Map<IEnumerable<FileDTO>>(fileDetails)
      };

      return model;
    }
  }
}
