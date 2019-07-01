using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.ProjectFile.GetAllFolder
{
  public class GetAllFileQuery : IRequest<FileViewModel>
  {
    public string path { get; set; }
  }
}
