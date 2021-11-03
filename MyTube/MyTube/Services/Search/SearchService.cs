namespace MyTube.Services.Search
{
    using System.Linq;

    using MyTube.Data;
    using MyTube.ViewModels.Search;

    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext context;

        public SearchService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public SearchVideosListViewModel FindVideos(string searchTerm)
        {
            var videos = this.context.Videos
                .Where(v => v.Title.Contains(searchTerm) || v.ApplicationUser.UserName.Contains(searchTerm))
                .Select(v => new SearchVideoInListViewModel
                {
                    Id = v.Id,
                    Title = v.Title,
                    VideoImageUrl = v.VideoImageUrl,
                    ApplicationUserId = v.ApplicationUserId,
                    ApplicationUser = v.ApplicationUser
                })
                .ToList();

            var viewModel = new SearchVideosListViewModel
            {
                Videos = videos
            };

            return viewModel;
        }
    }
}
