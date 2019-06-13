using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Common
{
    public class ConvertDate
    {
        public string ToDayAndMonth(DateTime dateTime)
        {
          string dateFomat = dateTime.ToString("F");
          return dateFomat;
        }
    }
}
