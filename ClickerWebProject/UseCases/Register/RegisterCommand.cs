using MediatR;

namespace ClickerWebProject.UseCases.Register;

public record RegisterCommand(string UserName,string Password) : IRequest<Unit>;
