using InstagramClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Application.Models.Requests.Posts
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(1000, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        public string PostDescription { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public Boolean IsStory { get; set; }
        [MaxLength(250, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        public string? LocationName { get; set; }
        [Range(-90, 90, ErrorMessage = ValidationConstants.INVALID_LATITUDE)]
        public float? Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = ValidationConstants.INVALID_LONGITUDE)]
        public float? Longitude { get; set; }
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string MediaUrl { get; set; } = null!;

    }
}
