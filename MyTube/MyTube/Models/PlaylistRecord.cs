namespace MyTube.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PlaylistRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public int VideoId { get; set; }

        public Video Video { get; set; }
    }
}
