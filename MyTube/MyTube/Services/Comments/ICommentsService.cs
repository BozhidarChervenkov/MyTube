namespace MyTube.Services.Comments
{
    using MyTube.ViewModels.Comment;

    public interface ICommentsService
    {
        void CreateComment(CreateCommentInputModel input);

        void CreateReply(CreateReplyInputModel input);
    }
}
