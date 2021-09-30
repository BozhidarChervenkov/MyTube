namespace MyTube.Services.Videos
{
    using MyTube.ViewModels.Home;
    using MyTube.ViewModels.Video;

    public interface IVideosService
    {
        void UploadVideo(UploadVideoFormModel input, string currentUserId);

        HomePageViewModel Videos(string sortTerm);
    }
}
