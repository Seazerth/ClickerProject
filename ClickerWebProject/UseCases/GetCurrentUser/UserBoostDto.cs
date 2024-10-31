using ClickerWebProject.Domain;

namespace ClickerWebProject.UseCases.GetCurrentUser;

public class UserBoostDto
{

    public int BoostId { get; init; }

    public long CurentPrice { get; init; }

    public long Quantity { get; init; }
}
