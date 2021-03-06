namespace MyTube.Models
{
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ReplyContentMinLength)]
        [MaxLength(ReplyContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
