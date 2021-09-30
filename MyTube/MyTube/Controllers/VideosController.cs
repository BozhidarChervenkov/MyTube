namespace MyTube.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using MyTube.Models;
    using MyTube.Services.Videos;
    using MyTube.ViewModels.Video;
    using System.Threading.Tasks;

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
        [Authorize]
        public IActionResult UploadVideo()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
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

        [HttpGet]
        public async Task<IActionResult> VideoById(int id)
        {
            bool doesVideoExist = this.videosService.DoesVideoExist(id);

            if (doesVideoExist == false)
            {
                return this.BadRequest();
            }

            var viewModel = await this.videosService.VideoByIdLogic(id);

            return this.View(viewModel);
        }
    }
}
