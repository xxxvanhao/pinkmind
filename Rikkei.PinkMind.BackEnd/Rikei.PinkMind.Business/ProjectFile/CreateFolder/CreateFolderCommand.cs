using MediatR;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.ProjectFile.CreateFolder
{
  public class CreateFolderCommand : IRequest
  {
    public string FolderPath { get; set; }
    public string FilePath { get; set; }
    public string TypeModel { get; set; }
    public string ImagePath { get; set; }
    public long CreateBy { get; set; }
    public DateTime CreateAt { get; set; }
    public long UpdateBy { get; set; }
    public DateTime LastUpdate { get; set; }
    [Column(TypeName = "bit")]
    public bool DelFlag { get; set; }
    [Column(TypeName = "timestamp")]
    [Timestamp]
    public byte[] CheckUpdate { get; set; }
    public string ProjectID { get; set; }
    public class Handler : IRequestHandler<CreateFolderCommand, Unit>
    {
      private readonly PinkMindContext _pmContext;
      public Handler(PinkMindContext pmContext)
      {
        _pmContext = pmContext;
      }
      public async Task<Unit> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
      {
        var entity = new ProjectFileUpload
        {
          FolderPath = request.FolderPath,
          FilePath = request.FilePath,
          TypeModel = "Folder",
          ImagePath = "Hihi",
          CreateBy = request.CreateBy,
          CreateAt = DateTime.UtcNow,
          UpdateBy = request.CreateBy,
          LastUpdate = DateTime.Now,
          DelFlag = true,
          ProjectID = request.ProjectID

        };
        _pmContext.ProjectFiles.Add(entity);
        await _pmContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
      }
    }
  }
}
