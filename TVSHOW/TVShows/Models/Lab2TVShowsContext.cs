using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TVShows.Models
{
    public class Lab2TVShowsContext : DbContext
    {
        public virtual DbSet<Studio> Studios { get; set; }
        public virtual DbSet<StudioShow> StudioShows { get; set; }
        public virtual DbSet<TVshow> TVshows { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public Lab2TVShowsContext(DbContextOptions<Lab2TVShowsContext>options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
