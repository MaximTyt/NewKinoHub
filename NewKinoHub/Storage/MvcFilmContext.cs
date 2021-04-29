using Microsoft.EntityFrameworkCore;
using NewKinoHub.Storage.Entity;

namespace NewKinoHub.Storage
{
    public class MvcFilmContext : DbContext
    {
        public MvcFilmContext(DbContextOptions<MvcFilmContext> options) : base(options)
        { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MediaImages> MediaImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Viewed> Vieweds { get; set; }


    }          
    
}

