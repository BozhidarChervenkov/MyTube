namespace MyTube.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static GlobalConstants.GlobalConstants;

    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(MinVideoTitleLength)]
        [MaxLength(MaxVideoTitleLength)]
        public string Title { get; set; }

        [Required]
        public string VideoUrl { get; set; }

        [MinLength(MinVideoDescriptionLength)]
        [MaxLength(MaxVideoDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
