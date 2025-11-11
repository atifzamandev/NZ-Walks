using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace NZ_Walks.API.Data
    {
    public class NZWalksAuthDbContext:IdentityDbContext
        {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> authDbContextOptions) : base(authDbContextOptions)
            {
            }

        protected override void OnModelCreating(ModelBuilder builder)
            {
            base.OnModelCreating(builder);

            var readRoleId = "f00383ca-4bd9-495a-b520-4b8af85b687e";
            var writeRoleId = "84382b71-7614-4b8c-bae7-f414a91a2b67";

            var roles = new List<IdentityRole>
            {

                new IdentityRole
                {
                    Id = readRoleId,
                    ConcurrencyStamp = readRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = writeRoleId,
                    ConcurrencyStamp= writeRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);

            }

        }
    }
