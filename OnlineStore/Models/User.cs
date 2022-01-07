using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents user.
    /// </summary>
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public List<Receipt> Receipts { get; set; }
        
        public int WishlistId { get; set; }
        
        [ForeignKey("WishlistId")]
        public Wishlist Wishlist { get; set; }
        
        public int ShoppingCartId { get; set; }
        
        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
    }
}