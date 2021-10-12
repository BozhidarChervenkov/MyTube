namespace MyTube.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Comment
    {
        public Comment()
        {
            this.Replies = new HashSet<Reply>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(CommentContentMinLength)]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int VideoId { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Reply> Replies { get; set; }
    }
}
