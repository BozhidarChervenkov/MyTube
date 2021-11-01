namespace MyTube.Services.Playlist
{
    using System.Threading.Tasks;

    using MyTube.ViewModels.Playlist;

    public interface IPlaylistService
    {
        Task Add(int videoId, string userId);

        VideoPlaylistViewModel All(string userId);
    }
}
