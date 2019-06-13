using Rikei.PinkMind.Business.Interface;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Rikei.PinkMind.Business.Implementation
{
  class IssueTypeResponsetory : IIssueTypeResponsetory
  {
    private string Successfull = "successful manipulation!";
    private string Err1 = "Update false! Because there are was a change before, please reload page!";
    private string Err2 = "false manipulation!";
    private string Err3 = "Update false! Because of An error occurred";
    PinkMindContext ctx;
    public IssueTypeResponsetory(PinkMindContext pinkMindContext)
    {
      ctx = pinkMindContext;
    }
    public string Delete(int id)
    {
      try
      {
        ctx.Issues.Remove(ctx.Issues.SingleOrDefault(x => x.ID == id));
        ctx.SaveChanges();
        return Successfull;
      }
      catch
      {
        return Err2;
      }
      throw new NotImplementedException();
    }

    public List<IssueType> GetAll()
    {
      List<IssueType> item  = ctx.IssueTypes.ToList();
      return item;
      throw new NotImplementedException();
    }

    public IssueType GetById(int id)
    {
      IssueType item = ctx.IssueTypes.SingleOrDefault(x => x.ID == id);
      return null;
      throw new NotImplementedException();
    }

    public string Insert(IssueType issueType)
    {
      try
      {
        ctx.IssueTypes.Add(issueType);
        ctx.SaveChanges();
        return Successfull;
      }
      catch
      {
        return Err2;
      }
      throw new NotImplementedException();
    }

    public string Update(IssueType issueType)
    {
      var item = ctx.IssueTypes.SingleOrDefault(x => x.ID == issueType.ID && x.LastUpdate == issueType.LastUpdate);
      if (item != null)
      {
        item.Name = issueType.Name;
        item.CreateAt = issueType.CreateAt;
        item.UpdateBy = issueType.UpdateBy; ;
        ctx.SaveChanges();
        return Successfull;
      }
      else
      {
        return Err1;
      }
      throw new NotImplementedException();
    }
  }
}
