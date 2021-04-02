using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeCat.Models
{
    public class AnimeInfo
    {
        public AnimeInfo()
        {
            AnimeGenres = new HashSet<AnimeGenre>();
            AnimeTranslations = new HashSet<AnimeTranslation>();
        }

        public int AnimeInfoId { get; set; }
        public string OriginalName { get; set; }
        public string Status { get; set; }
        public int ReleaseYear { get; set; }
        public string StudioName { get; set; }
        public string FilmDirector { get; set; }
        public int NumOfEpisodes { get; set; }
        public string AgeRating { get; set; }
        public string AnimeType { get; set; }
        public string Source { get; set; }
        public string Season { get; set; }
        public string Description { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual ICollection<AnimeGenre> AnimeGenres { get; set; }
        public virtual ICollection<AnimeTranslation> AnimeTranslations { get; set; }
    }
}

