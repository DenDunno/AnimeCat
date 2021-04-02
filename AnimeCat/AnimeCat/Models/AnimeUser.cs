using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace AnimeCat.Models
{
    public class AnimeUser : IdentityUser
    {
        public AnimeUser()
        {
            Comments = new HashSet<Comment>();
        }

        public int AnimeUserId { get; set; }
        public string NickName { get; set; }
        public bool IsVerified { get; set; }
        public int AvatarID { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
