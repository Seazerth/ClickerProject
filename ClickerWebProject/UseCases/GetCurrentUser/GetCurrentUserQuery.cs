using MediatR;

namespace ClickerWebProject.UseCases.GetCurrentUser;

public record GetCurrentUserQuery : IRequest<UserDto>;