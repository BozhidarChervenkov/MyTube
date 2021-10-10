namespace MyTube.ViewModels.Video
{
    using MyTube.ViewModels.Comment;
    using System;
    using System.Collections.Generic;

    public class VideoByIdViewModel
    {
        public VideoByIdViewModel()
        {
            this.PlayListVideos = new HashSet<VideoInPlayListViewModel>();
        }

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

        public string CurrentUserId { get; set; }

        public CreateCommentInputModel CreateCommentInputModel{get; set;}

        public ICollection<VideoInPlayListViewModel> PlayListVideos { get; set; }
    }
}
