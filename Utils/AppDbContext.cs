using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using UtilModels;

namespace Utils
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
            builder.Entity<ServiceModel>().Property(m => m.Service).HasConversion<int>();
            builder.Entity<UsersCredentialsModel>().HasMany(s => s.Services);
            builder.Entity<ServiceCredentialsModel>().Property(m => m.Service).HasConversion<int>();
            builder.Entity<PictureUrlModel>().Property(m => m.Service).HasConversion<int>();

            base.OnModelCreating(builder);
        }

        public DbSet<UsersCredentialsModel> UsersCredentialsModels { get; set; }
        public DbSet<ServiceModel> ServiceModel { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CookieModel> CookieModel { get; set; }
        public DbSet<ProjectionModel> ProjectionModel { get; set; }
        public DbSet<ServiceCredentialsModel> ServiceCredentialsModel { get; set; }
        public DbSet<PictureUrlModel> PictureUrlModel { get; set; }
        public DbSet<InstagramMediaModel> InstagramMediaModel { get; set; }
    }


}

