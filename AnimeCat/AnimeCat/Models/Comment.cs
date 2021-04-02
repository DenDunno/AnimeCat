using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeCat.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimeId { get; set; }
        public int AnimeUserId { get; set; }
        public string Text { get; set; }

        public virtual Anime Anime { get; set; }
        public virtual AnimeUser AnimeUser { get; set; }
    }
}
