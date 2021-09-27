namespace MyTube.Services
{
    using MyTube.ViewModels;

    public interface IVideosService
    {
        void UploadVideo(UploadVideoFormModel input, string currentUserId);
    }
}
