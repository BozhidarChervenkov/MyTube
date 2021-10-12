namespace MyTube.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using MyTube.ViewModels.Video;
    using MyTube.Services.Comments;

    [Authorize]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        // The input data is passed from the CreateCommentInputModel property in VideoByIdViewModel
        [HttpPost]
        public IActionResult SaveComment(VideoByIdViewModel input)
        {
            if (!ModelState.IsValid)
            {
                // Todo: Create an adequate error view
                return this.BadRequest();
            }

            this.commentsService.CreateComment(input.CreateCommentInputModel);

            return this.RedirectToAction("VideoById", "Videos", new { id = input.CreateCommentInputModel.VideoId });
        }

        // The input data is passed from the CreateReply property in VideoByIdViewModel
        [HttpPost]
        public IActionResult SaveReply(VideoByIdViewModel input)
        {
            if (!ModelState.IsValid)
            {
                // Todo: Create an adequate error view
                return this.BadRequest();
            }

            this.commentsService.CreateReply(input.CreateReplyInputModel);

            return this.RedirectToAction("VideoById", "Videos", new { id = input.CreateReplyInputModel.VideoId });
        }
    }
}
