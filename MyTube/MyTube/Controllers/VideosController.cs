namespace MyTube.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using MyTube.Models;
    using MyTube.Services.Videos;
    using MyTube.ViewModels.Video;

    public class VideosController : Controller
    {
        private readonly IVideosService videosService;
        private readonly UserManager<ApplicationUser> userManager;

        public VideosController(IVideosService videosService, UserManager<ApplicationUser> userManager)
        {
            this.videosService = videosService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult UploadVideo()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult UploadVideo(UploadVideoFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var currentUserId = this.userManager.GetUserId(this.User);
            this.videosService.UploadVideo(input, currentUserId);

            return this.RedirectToAction("Index","Home");
        }
    }
}
