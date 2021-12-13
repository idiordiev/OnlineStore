using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Models
{
    public class UserApplicationDbContext : IdentityDbContext<User>
    {
        public UserApplicationDbContext(DbContextOptions<UserApplicationDbContext> options): base(options)
        {

        }
    }
}