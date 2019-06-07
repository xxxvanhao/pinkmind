using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class Role
    {
        public int ID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public ICollection<TeamDetail> TeamDetails { get; set; }
    }
}
