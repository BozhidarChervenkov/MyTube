namespace MyTube.Services.Search
{
    using MyTube.ViewModels.Search;

    public interface ISearchService
    {
        SearchVideosListViewModel FindVideos(string searchTerm);
    }
}
