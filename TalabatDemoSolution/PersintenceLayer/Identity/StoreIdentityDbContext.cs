global using DomainLayer.Models.Identity;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PersintenceLayer.Identity;
public class StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Address>().ToTable("Addresses");
        builder.Entity<ApplicationUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UsersRoles");


        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();

    }
}
