using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AnimeCat.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("Anime")]
        public int AnimeId { get; set; }

        public int AnimeUserId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Anime Anime { get; set; }
    }
}
