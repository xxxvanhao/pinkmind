using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccess.Model
{
    class Context : DbContext
    {
        public Context()
        {

        }
        public DbSet<Issue> issues { get; set; }
        public DbSet<IssueType> issueTypes { get; set; }
    }
}
