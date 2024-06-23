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

            builder.Entity<App>()
            .HasOne(a => a.Users)
            .WithOne(a => a.App)
            .HasForeignKey<User>(c => c.Id);


            builder.Entity<User>()
            .HasOne(a => a.App)
            .WithOne(a => a.Users)
            .HasForeignKey<App>(c => c.Id);
        }


        public DbSet<App> Apps { get; set; }
    }
}
