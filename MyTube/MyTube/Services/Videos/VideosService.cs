namespace MyTube.Services.Videos
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels.Home;
    using MyTube.ViewModels.Video;

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

        public async Task<VideoByIdViewModel> VideoByIdLogic(int videoId)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == videoId);

            //Increase the views count by one and save changes to Db:
            video.ViewsCount++;
            await this.context.SaveChangesAsync();

            //Collect the view model information:
            var embeddedCode = EmbeddedCode(video.VideoUrl);
            var user = await this.userManager.FindByIdAsync(video.ApplicationUserId);

            var viewModel = new VideoByIdViewModel
            {
                Id = video.Id,
                Title = video.Title,
                EmbeddedCode = embeddedCode,
                VideoImageUrl = video.VideoImageUrl,
                Description = video.Description,
                ViewsCount = video.ViewsCount,
                LikesCount = video.LikesCount,
                CreatedOn = video.CreatedOn,
                ApplicationUserId = user.Id,
                UserName = user.UserName,
                AccountPictureUrl = user.AccountPictureUrl
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
