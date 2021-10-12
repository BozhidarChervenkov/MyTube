namespace MyTube.ViewModels.Comment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class CreateReplyInputModel
    {
        [Required]
        [DisplayName("Type your reply:")]
        [MinLength(ReplyContentMinLength)]
        [MaxLength(ReplyContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        public int CommentId { get; set; }
    }
}
