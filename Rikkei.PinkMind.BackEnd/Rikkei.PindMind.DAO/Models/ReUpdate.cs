using System;
using System.Collections.Generic;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class ReUpdate
    {
        public int ID { get; set; }
        public string AvatarPath { get; set; }
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public string IssueKey { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string UpdateTime { get; set; }

    }
}
