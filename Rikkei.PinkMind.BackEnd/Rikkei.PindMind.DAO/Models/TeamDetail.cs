using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rikkei.PindMind.DAO.Models
{
  public class TeamDetail
    {
        public int ID { get; set; }
        public long UserID { get; set; }
        public int TeamID { get; set; }
        public int RoleID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Joined On")]
        public DateTime JoinedOn { get; set; }
        [Display(Name = "Add By")]
        public long? AddBy { get; set; }
        [Column(TypeName = "bit")]
        public bool DelFlag { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
        public Team Team { get; set; }
    }
}
