using Rikei.PinkMind.Business.Interface;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rikei.PinkMind.Business.Implementation
{
  class CategoryReponsetory : IResponsetory<Category>
  {
    // return value
    private const int Success = 1;
    private const int False = -1;

    PinkMindContext ctx;
    public CategoryReponsetory(PinkMindContext pinkMindContext)
    {
      ctx = pinkMindContext;
    }
    public int Delete(int id)
    {
      try
      {
        var item = ctx.Categories.Where(x => x.ID == id);
        ctx.Remove(item);
        ctx.SaveChanges();
        return Success;
      }
      catch
      {
        return False;
      }

      throw new NotImplementedException();
    }
    public List<Category> GetAll()
    {
      return ctx.Categories.ToList();      
      throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
      return ctx.Categories.SingleOrDefault(x => x.ID == id);
      throw new NotImplementedException();
    }

    public int Insert(Category t)
    {
      try
      {
        ctx.Categories.Add(t);
        ctx.SaveChanges();
        return Success;
      }
      catch
      {
        return False;
      }
      throw new NotImplementedException();
    }

    public int Update(Category t)
    {
      try
      {
        Category item = ctx.Categories.SingleOrDefault(x => x.ID == t.ID);
        item.Name = t.Name;
        item.LastUpdate = DateTime.Now;
        ctx.SaveChanges();
        return Success;
      }
      catch
      {
        return False;
      }
      throw new NotImplementedException();
    }
  }
}
