namespace MyTube.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Videos = new HashSet<Video>();
        }

        public ICollection<Video> Videos { get; set; }
    }
}
