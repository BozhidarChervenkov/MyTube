namespace MyTube.ViewModels.Comment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class CreateCommentInputModel
    {
        [Required]
        [DisplayName("Type your comment:")]
        [MinLength(CommentContentMinLength)]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
    }
}
