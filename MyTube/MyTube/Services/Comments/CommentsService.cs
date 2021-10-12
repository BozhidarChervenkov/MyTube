namespace MyTube.Services.Comments
{
    using System;

    using MyTube.Data;
    using MyTube.Models;
    using MyTube.ViewModels.Comment;

    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext context;

        public CommentsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreateComment(CreateCommentInputModel input)
        {
            var comment = new Comment
            {
                Content = input.Content,
                VideoId = input.VideoId,
                ApplicationUserId = input.ApplicationUserId,
                CreatedOn = DateTime.Now
            };

            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }

        public void CreateReply(CreateReplyInputModel input)
        {
            var reply = new Reply
            {
                Content = input.Content,
                CommentId = input.CommentId,
            };

            this.context.Replies.Add(reply);
            this.context.SaveChanges();
        }
    }
}
