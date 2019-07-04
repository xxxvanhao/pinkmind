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
      var fileSelect = from fs in _pmContext.ProjectFiles
                       select new FileDTO
                       {
                         ID = fs.ID,
                         FolderPath = fs.FolderPath,
                         FilePath = fs.FilePath,
                         FileSize = fs.FileSize,
                         TypeModel = fs.TypeModel,
                         ImagePath = fs.ImagePath,
                         CreateBy = fs.CreateBy,
                         CreateName = _pmContext.Users.Where(u => u.ID == fs.UpdateBy).Single().FullName,
                         CreateAt = fs.CreateAt,
                         UpdateBy = fs.UpdateBy,
                         UpdateName = _pmContext.Users.Where(u => u.ID == fs.UpdateBy).Single().FullName,
                         LastUpdate = fs.LastUpdate,
                         DelFlag = fs.DelFlag,
                         ProjectID = fs.ProjectID,
                         CheckUpdate = fs.CheckUpdate
                         
                       };
      var file = fileSelect.Where( pf => pf.FolderPath == request.path).OrderByDescending(pf => pf.TypeModel == "Folder");
      var fileDetails = await file.ToListAsync(cancellationToken);

      var model = new FileViewModel
      {
        FileDTOs = _mapper.Map<IEnumerable<FileDTO>>(fileDetails)
      };

      return model;
    }
  }
}
