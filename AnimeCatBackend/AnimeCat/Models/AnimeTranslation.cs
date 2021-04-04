using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AnimeCat.Models
{
    public class AnimeTranslation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AnimeInfo")]
        public int AnimeInfoId { get; set; }

        [ForeignKey("Translation")]
        public int TranslationId { get; set; }

        public virtual AnimeInfo AnimeInfo { get; set; }
        public virtual Translation Translation { get; set; }
    }
}
