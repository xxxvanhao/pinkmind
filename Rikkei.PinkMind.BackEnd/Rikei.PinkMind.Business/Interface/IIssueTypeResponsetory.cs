using Rikkei.PindMind.DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rikei.PinkMind.Business.Interface
{
  interface IIssueTypeResponsetory
  {
    List<IssueType> GetAll();
    IssueType GetById(int id);
    string Update(IssueType issueType);
    string Insert(IssueType issueType);
    string Delete(int id);
  }
}
