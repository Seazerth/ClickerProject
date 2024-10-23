namespace ClickerWebProject.UseCases.GetBoosts;

public class GetBoostsDto
{
    public int Id { get; init; }
    public string Title { get; init; }

    public long Price { get; init; }

    public long Profit { get; init; }

    public byte[] Image { get; init; }

    public bool IsAuto { get; init; }
}
