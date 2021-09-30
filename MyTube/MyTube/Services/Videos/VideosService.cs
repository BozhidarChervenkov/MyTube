namespace MyTube.Services.Videos
{
    using System.Linq;

    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels.Home;
    using MyTube.ViewModels.Video;

    public class VideosService : IVideosService
    {
        private readonly ApplicationDbContext context;

        public VideosService(ApplicationDbContext context)
        {
            this.context = context;
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
    }
}
