using ClickerWebProject.Domain;
using ClickerWebProject.DomainServices;
using ClickerWebProject.Infrastructure.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace ClickerWebProject.UseCases.AddPoints;

public class AddPointsCommandHandler : IRequestHandler<AddPointsCommand, Unit>
{
    private readonly ICurrentUserAccessor currentUserAccessor;
    private readonly IAppDbContext appDbContext;

    public AddPointsCommandHandler(ICurrentUserAccessor currentUserAccessor, IAppDbContext appDbContext)
    {
        this.currentUserAccessor = currentUserAccessor;
        this.appDbContext = appDbContext;
    }

    public async Task<Unit> Handle(AddPointsCommand request, CancellationToken cancellationToken)
    {
        var userId = currentUserAccessor.GetCurrentUserId();
        var user = await appDbContext.ApplicationUser
            .Include(user => user.UserBoosts)
            .ThenInclude(ub => ub.Boost)
            .FirstAsync();

        var points = user.UserBoosts.GetProfit(shouldCalculateAutoBoosts: request.IsAuto) * request.Times;

        user.CurrentScore += points;
        user.RecordScore += points;

        await appDbContext.SaveChangesAsync();

        return Unit.Value;
    }
}