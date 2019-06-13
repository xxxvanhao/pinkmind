using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Interface
{
  public interface IIssueReponsetory
  {
    List<Issue> GetAll();
    Issue GetById(int id);
    string Update(Issue issue);
    string Insert(Issue issue);
    string Delete(int id);
  }
}
