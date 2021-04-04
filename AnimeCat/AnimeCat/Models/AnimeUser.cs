using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AnimeCat.Models
{
    [NotMapped]
    public class AnimeUser : IdentityUser
    {
        public AnimeUser()
        {
            Comments = new HashSet<Comment>();
        }

        public int AvatarID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
