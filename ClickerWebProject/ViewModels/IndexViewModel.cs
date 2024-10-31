using ClickerWebProject.UseCases.GetBoosts;
using ClickerWebProject.UseCases.GetCurrentUser;

namespace ClickerWebProject.ViewModels;

public class IndexViewModel
{
    public UserDto User { get; init; }

    public IReadOnlyCollection<GetBoostsDto> Boosts { get; init; }
}
