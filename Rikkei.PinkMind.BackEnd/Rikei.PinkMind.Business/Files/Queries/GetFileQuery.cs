using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Files.Queries
{
  public class GetFileQuery : IRequest<FileModel>
  {
    public int ID { get; set; }
  }
}