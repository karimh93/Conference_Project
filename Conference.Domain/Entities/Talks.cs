using System;
using System.Collections.Generic;

namespace Conference.Domain.Entities
{
    public partial class Talks
    {
        public Talks()
        {
            Schedules = new HashSet<Schedules>();
        }

        public int Id { get; set; }
        public int SpeakerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Edition { get; set; }

        public virtual Speakers Speaker { get; set; }
        public virtual ICollection<Schedules> Schedules { get; set; }

    }
}
