using System.Security.Claims;
using ClickerWebProject.Infrastructure.Abstractions;

namespace ClickerWebProject.Infrastructure.Implementations;

public class CurrentUserAccessor : ICurrentUserAccessor
{
    private IHttpContextAccessor contextAccessor;
    
    public CurrentUserAccessor(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }

    public Guid GetCurrentUserId()
    {
        if(contextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("Cannot get HTTP context.");
        }

        var idValue = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!Guid.TryParse(idValue, out var userId))
        {
            throw new InvalidOperationException("Cannot parse user ID.");
        }

        return userId;
    }
}
