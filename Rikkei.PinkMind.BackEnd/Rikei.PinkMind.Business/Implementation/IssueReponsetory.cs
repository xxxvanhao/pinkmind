using Rikei.PinkMind.Business.Interface;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rikei.PinkMind.Business.Implementation
{
  public class IssueReponsetory : IIssueReponsetory
  {
    PinkMindContext ctx;
    public IssueReponsetory(PinkMindContext pinkMindContext)
    {
      ctx = pinkMindContext;
    }
    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public List<Issue> GetAll()
    {
      var item = ctx.Issues.ToList();
      return item;
    }

    public void insert(Issue issue)
    {
      throw new NotImplementedException();
    }

    public void update(Issue issue)
    {
      throw new NotImplementedException();
    }
  }
}
