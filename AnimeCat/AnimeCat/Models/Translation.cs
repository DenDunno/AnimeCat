using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AnimeCat.Models
{
    public class Translation
    {
        public Translation()
        {
            AnimeTranslations = new HashSet<AnimeTranslation>();
        }

        [Key]
        public int TranslationId { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrganizationName { get; set; }

        [Required]
        [MaxLength(30)]
        public string TranslationType { get; set; }

        public virtual ICollection<AnimeTranslation> AnimeTranslations { get; set; }
    }
}
