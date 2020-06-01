using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVShows.Models
{
    public class StudioShow
    {
        public int ShowId { get; set; }
        public int StudioId { get; set; }
        public int Id { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual TVshow TVShows { get; set; }

    }
}
