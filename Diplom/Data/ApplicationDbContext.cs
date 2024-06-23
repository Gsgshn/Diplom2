using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace Diplom.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
       

        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {

        }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserApp>(e => e.HasKey(c => new { c.UserId, c.AppId }));
        }


        public DbSet<App> Apps { get; set; }
        public DbSet<UserApp> UserApps { get; set; }
    }
}
