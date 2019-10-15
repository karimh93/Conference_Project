using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conference.Domain.Entities
{
    public partial class Sponsors
    {
        public Sponsors()
        {
            SponsorPhoto = new HashSet<SponsorPhoto>();
        }

        [Required]
        [MaxLength(4)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Description { get; set; }
        public string PageSlug { get; set; }
        public int SponsorTypeId { get; set; }
        public bool Active { get; set; }
        public string Edition { get; set; }

        public virtual SponsorTypes SponsorType { get; set; }
        public virtual ICollection<SponsorPhoto> SponsorPhoto { get; set; }
    }
}
