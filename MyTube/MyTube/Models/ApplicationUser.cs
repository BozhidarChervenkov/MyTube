namespace MyTube.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Videos = new HashSet<Video>();
            this.Comments = new HashSet<Comment>();
            this.PlaylistRecords = new HashSet<PlaylistRecord>();
        }

        public string AccountPictureUrl { get; set; }

        public ICollection<Video> Videos { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<PlaylistRecord> PlaylistRecords { get; set; }
    }
}
