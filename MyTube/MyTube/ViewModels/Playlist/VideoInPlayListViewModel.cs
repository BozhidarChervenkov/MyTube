namespace MyTube.ViewModels.Playlist
{
    using System;

    public class VideoInPlayListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string VideoImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
