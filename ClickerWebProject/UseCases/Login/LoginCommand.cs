using MediatR;

namespace ClickerWebProject.UseCases.Login;

public record LoginCommand(string UserName, string Password) : IRequest<Unit>;
