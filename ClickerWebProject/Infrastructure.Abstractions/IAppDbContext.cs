using ClickerWebProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace ClickerWebProject.Infrastructure.Abstractions;

public interface IAppDbContext
{
    DbSet<ApplicationRole> ApplicationRoles { get; }

    DbSet<ApplicationUser> ApplicationUser { get; }

    DbSet<Boost> Boosts { get; }

    DbSet<Boost> UserBoosts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
