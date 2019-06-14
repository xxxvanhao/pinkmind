using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 3)]
        public string Email { get; set; }
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        public string PictureUrl { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string SpaceID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create At")]
        public DateTime CreateAt { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public Space Space { get; set; }
        public ICollection<TeamDetail> TeamDetails { get; set; } 
    }
}
