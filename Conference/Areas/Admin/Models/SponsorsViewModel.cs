using Conference.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conference.Areas.Admin.Models
{
    public class SponsorsViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Sponsor name can't be less than 2 characters")]
        [MaxLength(50, ErrorMessage = "Sponsor name can't have more than 50 characters")]
        public string Name { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        [Required]
        public string Description { get; set; }
        public string PageSlug { get; set; }
        [Required]
        public int SponsorTypeId { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Edition { get; set; }

        public virtual SponsorTypes SponsorType { get; set; }
        public virtual ICollection<SponsorPhoto> SponsorPhoto { get; set; }
    }
}
