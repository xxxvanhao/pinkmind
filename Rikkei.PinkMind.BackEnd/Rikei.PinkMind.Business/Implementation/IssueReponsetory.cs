using Rikei.PinkMind.Business.Interface;
using Rikkei.PindMind.DAO.Models;
using Rikkei.PinkMind.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rikei.PinkMind.Business.Implementation
{
  public class IssueReponsetory : IIssueReponsetory
  {
    private string Successfull = "successful manipulation!";
    private string Err1 = "Update false! Because there are was a change before, please reload page!";
    private string Err2 = "false manipulation!";
    private string Err3 = "Update false! Because of An error occurred";
    PinkMindContext ctx;
    public IssueReponsetory(PinkMindContext pinkMindContext)
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

    public List<Issue> GetAll()
    {
      var item = ctx.Issues.ToList();
      return item;
    }
  
    public Issue GetById(int id)
    {
      Issue IssItem = ctx.Issues.SingleOrDefault(x => x.ID == id);
      return IssItem;
    }
    public string Insert(Issue issue)
    {
      try
      {
        ctx.Issues.Add(issue);
        ctx.SaveChanges();
        return Successfull;
      }
      catch
      {
        return Err2;
      }
      throw new NotImplementedException();
    }

    public string Update(Issue issue)
    {
      var item = ctx.Issues.SingleOrDefault(x => x.ID == issue.ID && x.LastUpdate == issue.LastUpdate);
      if (item != null)
      {
        item.IssueType = issue.IssueType;
        item.AssigneeUser = issue.AssigneeUser;
        item.PriorityID = issue.PriorityID;
        item.ResolutionID = issue.ResolutionID;
        item.Status = issue.Status;
        item.Subject = issue.Subject;
        item.VersionID = issue.VersionID;
        item.MilestoneID = issue.MilestoneID;
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
