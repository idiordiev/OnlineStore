using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("OldPassword")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [DisplayName("NewPassword")]
        [DataType(DataType.Password)]
        [StringLength(64, ErrorMessage = "MinimumPasswordLength", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required]
        [DisplayName("ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = ("PasswordNotEqual"))]
        public string ConfirmPassword { get; set; }
    }
}