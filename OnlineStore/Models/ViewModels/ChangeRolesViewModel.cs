using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models.ViewModels
{
    /// <summary>
    /// Represents a viewmodel for changing roles of user.
    /// </summary>
    public class ChangeRolesViewModel
    {
        [DisplayName("UserId")]
        public string UserId { get; set; }
        
        [DisplayName("Username")]
        public string UserName { get; set; }
        
        [DisplayName("AllRoles")]
        public List<IdentityRole> AllRoles { get; set; }
        
        [DisplayName("UserRoles")]
        public IList<string> UserRoles { get; set; }
        
        public ChangeRolesViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}