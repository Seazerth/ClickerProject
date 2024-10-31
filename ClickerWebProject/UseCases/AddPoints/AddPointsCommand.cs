using MediatR;

namespace ClickerWebProject.UseCases.AddPoints;

public record AddPointsCommand(int Times, bool IsAuto = false) : IRequest<Unit>;