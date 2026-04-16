using InstagramClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace InstagramClone.Application.Models.Requests
{
    public class UpdatePasswordUserRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [Compare("Password", ErrorMessage = ValidationConstants.PASSWORDS_MUST_MATCH)]
        public string RewritePassword { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(200, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string NewPassword { get; set; } = null!;
    }
}
