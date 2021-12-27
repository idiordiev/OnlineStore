using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models.ViewModels
{
    public class ChangeRolesViewModel
    {
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