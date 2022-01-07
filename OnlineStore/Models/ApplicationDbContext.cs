using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    /// <summary>
    /// EF database context.
    /// </summary>
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        
        public DbSet<Wishlist> Wishlists { get; set; }
        
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}