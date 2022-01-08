using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Represents viewmodel for viewing user information.
    /// </summary>
    public class UserPageViewModel
    {
        [Required]
        [DisplayName("Id")]
        public string Id { get; set; }
        
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        
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