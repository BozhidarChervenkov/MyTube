namespace MyTube.ViewModels.Home
{
    using System;

    public class VideoInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public string VideoImageUrl { get; set; }

        public int ViewsCount { get; set; }

        public int LikesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AccountPictureUrl { get; set; }

        public string AccountName { get; set; }
    }
}
