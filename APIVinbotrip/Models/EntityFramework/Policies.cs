using Microsoft.AspNetCore.Authorization;

public class Policies
{
    public const string Dirigeant = "Dirigeant";
    public const string Client = "Client";
    public const string Dpo = "DPO";
    public const string ServiceVente = "Service Vente";
    public static AuthorizationPolicy DirigeantPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Dirigeant).Build();
    }
    public static AuthorizationPolicy ClientPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Client).Build();
    }
    public static AuthorizationPolicy DPOPolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Dpo).Build();
    }
    public static AuthorizationPolicy ServiceVentePolicy()
    {
        return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(ServiceVente).Build();
    }
}