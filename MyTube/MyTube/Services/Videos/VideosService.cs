namespace MyTube.Services.Videos
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels.Comment;
    using MyTube.ViewModels.Home;
    using MyTube.ViewModels.Video;

    using static GlobalConstants.GlobalConstants;

    public class VideosService : IVideosService
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public VideosService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public void UploadVideo(UploadVideoFormModel input, string currentUserId)
        {
            var video = new Video
            {
                Title = input.Title,
                VideoUrl = input.VideoUrl,
                VideoImageUrl = input.VideoImageUrl,
                Description = input.Description,
                ViewsCount = 0,
                CreatedOn = System.DateTime.Now,
                ApplicationUserId = currentUserId
            };

            this.context.Videos.Add(video);
            this.context.SaveChanges();
        }

        public HomePageViewModel Videos(string sortTerm)
        {
            var videos = this.context.Videos
                .Select(v => new VideoInListViewModel
                {
                    Id = v.Id,
                    Title = v.Title,
                    VideoUrl = v.VideoUrl,
                    VideoImageUrl = v.VideoImageUrl,
                    ViewsCount = v.ViewsCount,
                    LikesCount = v.LikesCount,
                    DislikesCount = v.DislikesCount,
                    CreatedOn = v.CreatedOn,
                    AccountName = v.ApplicationUser.UserName,
                    AccountPictureUrl = v.ApplicationUser.AccountPictureUrl
                });

            switch (sortTerm)
            {
                case null:
                    videos = videos.OrderBy(v => v.Id);
                    break;
                case "Latest":
                    videos = videos.OrderByDescending(v => v.CreatedOn);
                    break;
                case "Oldest":
                    videos = videos.OrderBy(v => v.CreatedOn);
                    break;
                case "Most Viewed":
                    videos = videos.OrderByDescending(v => v.ViewsCount);
                    break;
                case "Most Liked":
                    videos = videos.OrderBy(v => v.LikesCount);
                    break;
            }

            var viewModel = new HomePageViewModel
            {
                Videos = videos.ToList()
            };

            return viewModel;
        }

        public bool DoesVideoExist(int videoId)
        {
            var doesItExist = this.context.Videos.Any(v => v.Id == videoId);

            return doesItExist;
        }

        public async Task<VideoByIdViewModel> VideoByIdLogic(int videoId, string currentUserId)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            // Increase the views count by one and save changes to Db:
            video.ViewsCount++;
            await this.context.SaveChangesAsync();

            // Extract the embedded code so that it can be used in the player
            var embeddedCode = EmbeddedCode(video.VideoUrl);

            // Find the video publisher and use his info in the view
            var user = await this.userManager.FindByIdAsync(video.ApplicationUserId);

            // Get random n count songs for the player
            var playlistSongs = this.context.Videos
                .Where(v=>v.Id != videoId)
                .OrderBy(r => Guid.NewGuid())
                .Select(v => new VideoInPlayListViewModel
                {
                    Id = v.Id,
                    Title = v.Title,
                    VideoImageUrl = v.VideoImageUrl,
                    ViewsCount = v.ViewsCount
                })
                .Take(PlaylistNumberOfSongs)
                .ToList();

            // Get the video comments and filter only the needed info into view model
            var videoComments = this.context.Comments
                .Where(c => c.VideoId == videoId)
                .Select(c=> new CommentViewModel 
                {
                    Id = c.Id,
                    Content = c.Content,
                    AccountPictureUrl = c.ApplicationUser.AccountPictureUrl,
                    UserName = c.ApplicationUser.UserName,
                    CreatedOn = c.CreatedOn,
                    Replies = c.Replies
                })
                .ToList();

            // Fill the final view model information
            var viewModel = new VideoByIdViewModel
            {
                Id = video.Id,
                Title = video.Title,
                EmbeddedCode = embeddedCode,
                VideoImageUrl = video.VideoImageUrl,
                Description = video.Description,
                ViewsCount = video.ViewsCount,
                LikesCount = video.LikesCount,
                DislikesCount = video.DislikesCount,
                CreatedOn = video.CreatedOn,
                ApplicationUserId = user.Id,
                UserName = user.UserName,
                AccountPictureUrl = user.AccountPictureUrl,
                CurrentUserId = currentUserId,
                Comments = videoComments,
                PlayListVideos = playlistSongs
            };

            return viewModel;
        }

        private string EmbeddedCode(string videoUrl)
        {
            var path = videoUrl;

            int position = path.IndexOf("=") + 1;
            var embeddedCode = path.Substring(position, 11);

            return embeddedCode;
        }
    }
}
