using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents shopping cart.
    /// </summary>
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        
        public User User { get; set; }
        
        public List<Product> Products { get; set; }
    }
}