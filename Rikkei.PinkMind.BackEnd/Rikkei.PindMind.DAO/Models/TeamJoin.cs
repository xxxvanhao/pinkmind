using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class TeamJoin
    {
        public long ID { get; set; }
        public long TeamID { get; set; }
        public string ProjectID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join On")]
        public DateTime JoinOn { get; set; }
        [Display(Name = "Add By")]
        public long AddBy { get; set; }
        [Column(TypeName = "bit")]
        public bool DelFlag { get; set; }
        public Team Team { get; set; }
        public Project Project { get; set; }
    }
}
