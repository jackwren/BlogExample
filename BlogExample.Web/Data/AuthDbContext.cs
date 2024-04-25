using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogExample.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed roles (User,Admin & SuperAdmin)
            var userRoleId = "64937f3e-3eef-4068-9b72-2ea13333b1c8";
            var adminRoleId = "c6efdb71-444f-41ae-abfa-b443a253f8e1";
            var superAdminRoleId = "0bbb7e1e-2d28-4637-adc1-15355d85b40d";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                }
            };
            
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdminUser
            var superAdminId = "d858b166-d747-46eb-9b36-c24779972127";
            var superAdminUser = new IdentityUser
            {
                UserName = "SuperAdmin@blogexample.com",
                Email = "superadmin@blogexample.com",
                NormalizedEmail = "SuperAdmin@blogexample.com".ToUpper(),
                NormalizedUserName = "SuperAdmin@blogexample.com".ToUpper(),
                Id = superAdminId
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "SuperAdmin@123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add all the Roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
