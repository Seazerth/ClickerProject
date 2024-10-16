using MediatR;

namespace ClickerWebProject.UseCases.Login.Logout;

public record LogoutCommand : IRequest<Unit>;
