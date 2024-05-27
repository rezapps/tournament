namespace Tournament.Core.Entities;

public class Tourney
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime StartDate { get; set; }
    public ICollection<Game> Games { get; set; } = [];
}
