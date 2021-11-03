namespace MyTube.ViewModels.Search
{
    using MyTube.Models;

    public class SearchVideoInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string VideoImageUrl { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
