using ClickerWebProject.UseCases.GetBoosts;

namespace ClickerWebProject.ViewModels;

public class IndexViewModel
{
    public IReadOnlyCollection<GetBoostsDto> Boosts { get; init; }
}
