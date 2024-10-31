using MediatR;

namespace ClickerWebProject.UseCases.Logout;

public record LogoutCommand : IRequest<Unit>;
