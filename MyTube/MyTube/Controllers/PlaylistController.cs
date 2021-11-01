namespace MyTube.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using MyTube.Models;
    using MyTube.Services.Playlist;

    [Authorize]
    public class PlaylistController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPlaylistService playlistService;

        public PlaylistController(UserManager<ApplicationUser> userManager, IPlaylistService playlistService)
        {
            this.userManager = userManager;
            this.playlistService = playlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Add(int videoId)
        {
            var userId = userManager.GetUserId(this.User);

            await this.playlistService.Add(videoId, userId);


            return this.RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult All()
        {
            var userId = userManager.GetUserId(this.User);

            var viewModel = this.playlistService.All(userId);

            return this.View(viewModel);
        }
    }
}
