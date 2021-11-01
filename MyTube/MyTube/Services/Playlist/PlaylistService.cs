namespace MyTube.Services.Playlist
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels.Playlist;

    public class PlaylistService : IPlaylistService
    {
        private readonly ApplicationDbContext context;

        public PlaylistService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task Add(int videoId, string userId)
        {
            var doesRecordExist = this.context.PlayListRecords.Any(pr => pr.VideoId == videoId && pr.ApplicationUserId == userId);

            if (doesRecordExist == false)
            {
                var playlistRecord = new PlaylistRecord
                {
                    ApplicationUserId = userId,
                    VideoId = videoId
                };

                await this.context.AddAsync(playlistRecord);
                await this.context.SaveChangesAsync();
            }
        }

        public VideoPlaylistViewModel All(string userId)
        {
            var videos = this.context.PlayListRecords
                .Where(pr => pr.ApplicationUserId == userId)
                .Select(pr => new VideoInPlayListViewModel
                {
                    Id = pr.Id,
                    Title = pr.Video.Title,
                    VideoImageUrl = pr.Video.VideoImageUrl,
                    CreatedOn = pr.Video.CreatedOn
                })
                .OrderBy(pr=>pr.CreatedOn)
                .ToList();

            var viewModel = new VideoPlaylistViewModel
            {
                Playlist = videos
            };

            return viewModel;
        }
    }
}
