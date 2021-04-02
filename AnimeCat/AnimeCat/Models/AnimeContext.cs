using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeCat.Models
{
    public class AnimeContext : DbContext
    {
        public virtual DbSet<Anime> Animes { get; set; }
        public virtual DbSet<AnimeInfo> AnimeInfoes { get; set; }
        public virtual DbSet<AnimeGenre> AnimeGenres { get; set; }
        public virtual DbSet<AnimeTranslation> AnimeTranslations { get; set; }
        public virtual DbSet<Translation> Translations { get; set; }
        public virtual DbSet<AnimeUser> AnimeUsers { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
    