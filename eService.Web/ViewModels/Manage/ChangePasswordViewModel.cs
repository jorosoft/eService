using System.ComponentModel.DataAnnotations;

namespace eService.Web.ViewModels.Manage
{
    public class ChangePasswordViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текуща парола")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори новата парола")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}