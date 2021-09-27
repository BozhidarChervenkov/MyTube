namespace MyTube.Services
{
    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels;

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
                Description = input.Description,
                CreatedOn = System.DateTime.Now,
                ApplicationUserId = currentUserId
            };

            this.context.Videos.Add(video);
            this.context.SaveChanges();
        }
    }
}
