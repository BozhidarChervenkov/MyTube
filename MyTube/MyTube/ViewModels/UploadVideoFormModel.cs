namespace MyTube.ViewModels
{    
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using MyTube.Models;

    using static GlobalConstants.GlobalConstants;

    public class UploadVideoFormModel
    {
        [Required]
        [MinLength(MinVideoTitleLength)]
        [MaxLength(MaxVideoTitleLength)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Video Url")]
        public string VideoUrl { get; set; }

        [MinLength(MinVideoDescriptionLength)]
        [MaxLength(MaxVideoDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
