namespace MyTube.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using MyTube.Services.Search;
    using MyTube.ViewModels.Home;

    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public IActionResult Search(HomePageViewModel input)
        {
            var searchTerm = input.SearchTerm;

            var viewModel = this.searchService.FindVideos(searchTerm);

            return this.View(viewModel);
        }
    }
}
