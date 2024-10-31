using ClickerWebProject.Domain;
using ClickerWebProject.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClickerWebProject.Infrastructure.DataAccess
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid> , IAppDbContext
    {
        public DbSet<ApplicationRole> ApplicationRoles { get; private set; }

        public DbSet<ApplicationUser> ApplicationUser { get; private set; }

        public DbSet<Boost> Boosts { get; private set; }

        public DbSet<Boost> UserBoosts { get; private set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserBoost>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBoosts)
                .HasForeignKey(ub => ub.UserId);

            builder.Entity<UserBoost>()
                .HasOne(ub => ub.Boost)
                .WithMany()
                .HasForeignKey(ub => ub.BoostId);
        }
    }
}
