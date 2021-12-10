using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// A model for Account/Login()
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
        
        [DisplayName("RememberMe")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}