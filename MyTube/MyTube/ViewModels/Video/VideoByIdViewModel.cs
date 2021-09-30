namespace MyTube.ViewModels.Video
{
    using System;

    using MyTube.Models;

    public class VideoByIdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string EmbeddedCode { get; set; }

        public string VideoImageUrl { get; set; }

        public string Description { get; set; }

        public int ViewsCount { get; set; }

        public int LikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ApplicationUserId { get; set; }

        public string UserName { get; set; }

        public string AccountPictureUrl { get; set; }
    }
}
