using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AnimeCat.Models
{
    public class Genre
    {
        public Genre()
        {
            AnimeGenres = new HashSet<AnimeGenre>();
        }

        [Key]
        public int GenreId { get; set; }

        [Required]
        [MaxLength(20)]
        public string GenreName { get; set; }

        [Required]
        public string Description { get; set; }
        

        public virtual ICollection<AnimeGenre> AnimeGenres { get; set; }
    }
}
