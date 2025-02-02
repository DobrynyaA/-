using Microsoft.AspNetCore.Identity;
using NikePro.Data;

public class SeedData
{
    public async Task InitializeAsync(ApplicationDbContext context)
    {

        var role1 = new IdentityRole("Admin");

        var role2 = new IdentityRole("Employee");

        var role3 = new IdentityRole("Client");

        await context.Roles.AddAsync(role1);

        await context.Roles.AddAsync(role2);

        await context.Roles.AddAsync(role3);

        var user1 = new ApplicationUser
        {
            UserName = "employee@mail.ru",
            Name = "Andrey",
            Surname = "Dobrynyan",
            Patronymic = "Vladislavovich",
            BirthdayDate = new DateTime(2002, 06, 16).ToUniversalTime(),
            Phone = "89176654237",
            NormalizedEmail = "EMPLOYEE@MAIL.RU",
            NormalizedUserName = "EMPLOYEE@MAIL.RU",
            LockoutEnabled = true,
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        user1.PasswordHash = passwordHasher.HashPassword(user1, "t2f4t5qQ!");

        var res = await context.Users.AddAsync(user1);

        await context.SaveChangesAsync();

        await context.UserRoles.AddAsync(
            new IdentityUserRole<string>
            {
                RoleId = role2.Id,
                UserId = user1.Id
            }
        );
        await context.SaveChangesAsync();
    }
}
