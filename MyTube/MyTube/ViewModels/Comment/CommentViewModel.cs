namespace MyTube.ViewModels.Comment
{
    using System;
    using System.Collections.Generic;

    using MyTube.Models;

    public class CommentViewModel
    {
        public CommentViewModel()
        {
            this.Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string AccountPictureUrl { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
