using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// A model for Users/Create()
    /// </summary>
    public class CreateUserViewModel
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
        
        [DisplayName("FirstName")] 
        public string FirstName { get; set; }
        
        [DisplayName("LastName")] 
        public string LastName { get; set; }
        
        [DisplayName("Address")]
        public string Address { get; set; }
        
        [DisplayName("City")]
        public string City { get; set; }
        
        [DisplayName("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}