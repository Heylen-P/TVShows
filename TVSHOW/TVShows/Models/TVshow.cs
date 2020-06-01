using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TVShows.Models
{
    public class TVshow
    {
        public TVshow()
        {
            StudioShow = new List<StudioShow>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<StudioShow> StudioShow { get; set; }
    }
}
