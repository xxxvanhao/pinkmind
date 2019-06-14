using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
  }
}
