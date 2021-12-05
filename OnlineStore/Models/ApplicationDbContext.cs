using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Goods> Goods { get; set; }
    }
}