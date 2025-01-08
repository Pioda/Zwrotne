namespace Zwrotne.Domain;

public abstract class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

public class AuthenticatedUser : User
{
    public string Email { get; private set; }
    public string Password { get; private set; }
}

public class AnonymousUser : User
{
    public AnonymousUser()
    {
        
    }
    public string Token { get; set; }
}
