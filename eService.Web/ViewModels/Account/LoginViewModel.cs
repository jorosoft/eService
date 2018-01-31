using System.ComponentModel.DataAnnotations;

namespace eService.Web.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [Display(Name = "Потребител")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }

        [Display(Name = "Запомни?")]
        public bool RememberMe { get; set; }
    }
}