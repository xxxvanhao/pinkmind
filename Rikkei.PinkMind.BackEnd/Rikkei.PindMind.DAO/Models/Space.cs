using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rikkei.PindMind.DAO.Models
{
    public class Space
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Space Name")]
        public string SpaceID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }
        [Required]
        public long CreateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create At")]
        public DateTime CreateAt { get; set; }
        [Display(Name = "Update By")]
        [Required]
        public long UpdateBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Update")]
        public DateTime LastUpdate { get; set; }
        [Column(TypeName = "bit")]
        public bool DelFlag { get; set; }
        [Column(TypeName = "timestamp")]
        [Timestamp]
        public byte[] CheckUpdate { get; set; }
        public ICollection<SpaceControl> SpaceControls { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
