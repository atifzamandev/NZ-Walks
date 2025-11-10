using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace NZ_Walks.API.Data
    {
    public class NZWalksAuthDbContext:IdentityDbContext
        {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> authDbContextOptions) : base(authDbContextOptions)
            {
            }

        }
    }
