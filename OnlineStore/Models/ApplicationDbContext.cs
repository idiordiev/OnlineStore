using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Goods> Goods { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<DiscountedGoods> DiscountedGoods { get; set; }
        
        public DbSet<Receipt> Receipts { get; set; }
    }
}