using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models.ViewModels
{
    public class ChangeRolesViewModel
    {
        public string UserId { get; set; }
        
        public string UserName { get; set; }
        
        public List<IdentityRole> AllRoles { get; set; }
        
        public IList<string> UserRoles { get; set; }
        
        public ChangeRolesViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}