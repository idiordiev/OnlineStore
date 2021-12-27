using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    // TODO: переделать бд
    // TODO: поместить оба контекста в один
    // TODO: комменты в моделях
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
    }
}