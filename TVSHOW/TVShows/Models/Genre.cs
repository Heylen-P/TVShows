using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TVShows.Models;

namespace TVShows.Models
{
    public class Genre
    {
        public Genre()
        {
            TVshows = new List<TVshow>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage ="The field must not be empty")]
        [Display(Name ="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field must not be empty")]
        [Display(Name = "Information about genre")]
        public string Info { get; set; }
        public virtual ICollection<TVshow> TVshows { get; set; }
    }
}
