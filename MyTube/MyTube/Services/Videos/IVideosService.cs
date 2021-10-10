namespace MyTube.Services.Videos
{
    using System.Threading.Tasks;

    using MyTube.ViewModels.Home;
    using MyTube.ViewModels.Video;
    
    public interface IVideosService
    {
        void UploadVideo(UploadVideoFormModel input, string currentUserId);

        HomePageViewModel Videos(string sortTerm);

        bool DoesVideoExist(int videoId);

        Task<VideoByIdViewModel> VideoByIdLogic(int videoId, string currentUserId);
    }
}
