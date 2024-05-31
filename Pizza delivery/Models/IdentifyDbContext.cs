using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace Pizza_delivery.Models
{
    public class IdentifyDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentifyDbContext(DbContextOptions<IdentifyDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./users.sqlite");
        }
    }
}
