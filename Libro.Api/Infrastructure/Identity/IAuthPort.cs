using System.Security.Claims;

namespace Libro.Api.Infrastructure.Identity;

public interface IAuthPort
{
    Guid? Id { get; }
    bool Authenticated { get; }
}

public class AuthAdapter(IHttpContextAccessor httpContextAccessor) : IAuthPort
{
    public Guid? Id => FindId(ClaimTypes.NameIdentifier);

    public bool Authenticated => httpContextAccessor.HttpContext!.User.Identity?.IsAuthenticated == true;

    private Guid? FindId(string claimName)
    {
        var value = httpContextAccessor.HttpContext!.User.FindFirstValue(claimName);
        return value != null ? Guid.Parse(value) : null;
    }
}