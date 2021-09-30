namespace MyTube.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using MyTube.Models;
    using MyTube.Services.Videos;

    public class HomeController : Controller
    {
        private readonly IVideosService videosService;

        public HomeController(IVideosService videosService)
        {
            this.videosService = videosService;
        }

        public IActionResult Index(string sortTerm)
        {
            var viewModel = this.videosService.Videos(sortTerm);

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
