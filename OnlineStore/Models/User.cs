using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public List<Receipt> Receipts { get; set; }
    }
}