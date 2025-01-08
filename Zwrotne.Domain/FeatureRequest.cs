using System.Globalization;

namespace Zwrotne.Domain;

public class FeatureRequest
{
    protected FeatureRequest() { }
    public FeatureRequest(string text, string title, Board board)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException($"\"{nameof(text)}\" kann nicht NULL oder leer sein.", nameof(text));
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException($"\"{nameof(title)}\" darf nicht NULL oder ein Leerraumzeichen sein.", nameof(title));
        }

        Text = text;
        Title = title;
        Board = board;
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public string Text { get; protected set; }
    public string Title { get; protected set; }
    public virtual Board Board { get; set; }

}