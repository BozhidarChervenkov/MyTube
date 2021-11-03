namespace MyTube.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            this.Videos = new HashSet<VideoInListViewModel>();
        }

        public string SearchTerm { get; set; }

        public ICollection<VideoInListViewModel> Videos { get; set; }
    }
}
