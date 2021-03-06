using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    /// <summary>
    /// Represents wishlist.
    /// </summary>
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }
        
        public User User { get; set; }
        
        public List<Product> Products { get; set; }
    }
}