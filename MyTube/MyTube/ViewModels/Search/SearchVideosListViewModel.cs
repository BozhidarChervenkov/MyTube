namespace MyTube.ViewModels.Search
{
    using System.Collections.Generic;

    public class SearchVideosListViewModel
    {
        public SearchVideosListViewModel()
        {
            this.Videos = new HashSet<SearchVideoInListViewModel>();
        }

        public ICollection<SearchVideoInListViewModel> Videos { get; set; }
    }
}
