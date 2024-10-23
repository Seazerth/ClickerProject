using MediatR;

namespace ClickerWebProject.UseCases.GetBoosts;

public record GetBoostsQuery : IRequest<IReadOnlyCollection<GetBoostsDto>>;
