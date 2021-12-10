using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// A model for Account/Register()
    /// </summary>
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DisplayName("ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ("PasswordNotEqual"))]
        public string ConfirmPassword { get; set; }
        
    }
}