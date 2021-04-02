using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeCat.Models
{
    public class AnimeTranslation
    {
        public int Id { get; set; }
        public int AnimeInfoId { get; set; }
        public int TranslationId { get; set; }

        public virtual AnimeInfo AnimeInfo { get; set; }
        public virtual Translation Translation { get; set; }
    }
}
