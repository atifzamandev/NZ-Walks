using Microsoft.AspNetCore.Identity;

namespace NZ_Walks.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
