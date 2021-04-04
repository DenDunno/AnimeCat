using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AnimeCat.Models
{
    public class Anime
    {
        public Anime()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int AnimeId { get; set; }

        [Required]
        public string Poster { get; set; }

        [Required]
        [MaxLength(50)]
        public string AnimeName { get; set; }

        [Required]
        public float Rating { get; set; }

        [ForeignKey("AnimeInfo")]
        public int AnimeInfoId { get; set; }

        public virtual AnimeInfo AnimeInfo { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
