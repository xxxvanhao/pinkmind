using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Interface
{
  interface IResponsetory<T>
  where T : class
  {       
        List<T> GetAll();
        T GetById(int id);
        int Insert(T t);
        int Update(T t);
        int Delete(int id);
    }
}
