using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest
    {
    public long ID { get; set; }
    }
}
