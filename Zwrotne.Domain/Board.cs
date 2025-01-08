namespace Zwrotne.Domain;
public class Board
{
    public Board(string name, bool allowAnonymous = false)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }

        Name = name;
        AllowAnonymous = allowAnonymous;
    }

    protected Board() { }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; private set; }
    public bool AllowAnonymous { get; private set; }
    public string Description { get; set; }
    public virtual ICollection<FeatureRequest> FeatureRequests { get; set; } = [];
}
