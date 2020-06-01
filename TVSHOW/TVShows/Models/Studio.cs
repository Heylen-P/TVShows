using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVShows.Models
{
    public class Studio
    {
        public Studio()
        {
            StudioShow = new List<StudioShow>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public virtual ICollection<StudioShow> StudioShow { get; set; }
    }
}
