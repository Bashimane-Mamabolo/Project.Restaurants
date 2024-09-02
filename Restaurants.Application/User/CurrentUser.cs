namespace Restaurants.Application.User;

public class CurrentUser(string Id, string Email, IEnumerable<string> Roles)
{
    public bool IsInRole( string role) => Roles.Contains(role);
}
