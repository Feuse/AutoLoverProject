using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseContext
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().Property(m => m.Service).HasConversion<int>();
            builder.Entity<ApplicationUser>().HasMany<Message>(m => m.Messages).WithOne(u => u.User).IsRequired();
            base.OnModelCreating(builder);
        }


        public DbSet<Message> Messages { get; set; }
        public DbSet<UsersCredentialsModel> UsersCredentialsModels { get; set; }
    }
}
