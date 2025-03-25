using Microsoft.AspNetCore.Authorization;

public class Policies
{
    public const string Dirigeant = "Dirigeant";
    public const string Client = "Client";
    public static AuthorizationPolicy DirigeantPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Dirigeant).Build();
    }
    public static AuthorizationPolicy ClientPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Client).Build();
    }
}