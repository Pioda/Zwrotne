namespace Zwrotne.Domain;

public class Vote
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Comment { get; private set; }
    public User VotedBy { get; set; }
    public VoteType Type { get; set; }
}

public enum VoteType
{
    Up,
    Down
}

public class UpVote : Vote
{

}

public class DownVote : Vote
{

}