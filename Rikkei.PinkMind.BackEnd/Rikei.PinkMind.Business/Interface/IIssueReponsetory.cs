using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Interface
{
  public interface IIssueReponsetory
  {
    List<Issue> GetAll();
    void update(Issue issue);
    void insert(Issue issue);
    void Delete(int id);
  }
}
