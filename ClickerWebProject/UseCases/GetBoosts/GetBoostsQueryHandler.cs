using AutoMapper;
using ClickerWebProject.Infrastructure.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ClickerWebProject.UseCases.GetBoosts;

public class GetBoostsQueryHandler : IRequestHandler<GetBoostsQuery, IReadOnlyCollection<GetBoostsDto>>
{

    private IAppDbContext appDbContext;
    private IMapper mapper;

    public GetBoostsQueryHandler(IAppDbContext appDbContext, IMapper mapper)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<IReadOnlyCollection<GetBoostsDto>> Handle(GetBoostsQuery request, CancellationToken cancellationToken)
    {
        return await mapper
            .ProjectTo<GetBoostsDto>(appDbContext.Boosts)
            .ToArrayAsync();
    }
}
