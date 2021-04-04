using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Key]
        public int AnimeInfoId { get; set; }
        
        [Required]
        [MaxLength(70)]
        public string OriginalName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        [MaxLength(70)]
        public string StudioName { get; set; }

        [Required]
        [MaxLength(70)]
        public string FilmDirector { get; set; }

        [Required]
        public int NumOfEpisodes { get; set; }

        [Required]
        [MaxLength(50)]
        public string AgeRating { get; set; }

        [Required]
        [MaxLength(50)]
        public string AnimeType { get; set; }

        [Required]
        [MaxLength(30)]
        public string Source { get; set; }

        [Required]
        [MaxLength(5)]
        public string Season { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual ICollection<AnimeGenre> AnimeGenres { get; set; }
        public virtual ICollection<AnimeTranslation> AnimeTranslations { get; set; }
    }
}

