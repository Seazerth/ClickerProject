using ClickerWebProject.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClickerWebProject.UseCases.Logout;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Unit>
{
    private SignInManager<ApplicationUser> singInManager;

    public LogoutCommandHandler(SignInManager<ApplicationUser> singInManager)
    {
        this.singInManager = singInManager;
    }

    public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await singInManager.SignOutAsync();

        return Unit.Value;
    }
}
