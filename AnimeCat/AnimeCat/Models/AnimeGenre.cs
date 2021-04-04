using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AnimeCat.Models
{
    public class AnimeGenre
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AnimeInfo")]
        public int AnimeInfoId { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public virtual AnimeInfo AnimeInfo { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
