using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kitabim.Models;

namespace Kitabim.Data
{
    public class KitabimDbContext : IdentityDbContext<UygulamaUser>
    {
        public KitabimDbContext(DbContextOptions<KitabimDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
     }
}






