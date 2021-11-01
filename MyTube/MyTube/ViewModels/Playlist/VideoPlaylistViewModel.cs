namespace MyTube.ViewModels.Playlist
{
    using System.Collections.Generic;

    public class VideoPlaylistViewModel
    {
        public VideoPlaylistViewModel()
        {
            this.Playlist = new HashSet<VideoInPlayListViewModel>();
        }

        public ICollection<VideoInPlayListViewModel> Playlist { get; set; }
    }
}
