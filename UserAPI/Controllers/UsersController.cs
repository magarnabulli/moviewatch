using Common.Dtos;
using Microsoft.AspNetCore.Identity;

namespace UserAPI.Controllers
{
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		public UsersController(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager) => (userManager, roleManager) = (_userManager, _roleManager);
		private async Task<IResult> AddUser(string email, string password)
		{
			try
			{
				if (!ModelState.IsValid) return Results.BadRequest();

				var existingUser = await userManager.FindByEmailAsync(email);
				if (existingUser is not null) return Results.BadRequest();

				User newUser = new()
				{
					Email = email,
					EmailConfirmed = true,
					UserName = email
				};

				IdentityResult result = await userManager.CreateAsync(newUser, password);

				if (result.Succeeded) return Results.Ok();
			}
			catch { }

			return Results.BadRequest();
		}
		private async Task<IResult> AddRoles(string email, List<string> roles)
		{
			try
			{
				if (!ModelState.IsValid) return Results.BadRequest();

				var user = await userManager.FindByEmailAsync(email);
				if (user is null) return Results.BadRequest();

				IdentityResult result = await userManager.AddToRolesAsync(user, roles);

				if (result.Succeeded) return Results.Ok();
			}
			catch { }

			return Results.BadRequest();
		}
		[Route("api/users/seed")]
		[HttpPost]
		public async Task<IResult> Seed()
		{
			try
			{
				await roleManager.CreateAsync(new IdentityRole { Id = "1", Name = UserRole.Admin });
				await roleManager.CreateAsync(new IdentityRole { Id = "2", Name = UserRole.Customer });
				await roleManager.CreateAsync(new IdentityRole { Id = "3", Name = UserRole.Registered });

				var john = "john@vod.com";
				var jane = "jane@vod.com";
				var password = "Pass123__";

				await AddUser(john, password);
				await AddRoles(john, new List<string> { UserRole.Admin, UserRole.Customer, UserRole.Registered });
				await AddUser(jane, password);
				await AddRoles(jane, new List<string> { UserRole.Customer, UserRole.Registered });

				return Results.Ok();
			}
			catch { }

			return Results.BadRequest();
		}
		[Route("api/users/register")]
		[HttpPost]
		public async Task<IResult> Register(RegisterUserDto registerUserDTO)
		{
			try
			{
				var result = await AddUser(registerUserDTO.Email, registerUserDTO.Password);

				if (result.Equals(Results.BadRequest())) return Results.BadRequest();

				result = await AddRoles(registerUserDTO.Email, registerUserDTO.Roles);

				return Results.Ok();
			}
			catch { }

			return Results.BadRequest();
		}

		[Route("api/users/paid")]
		[HttpPost]
		public async Task<IResult> Paid(PaidCustomerDto paidCustomerDTO) =>
			await AddRoles(paidCustomerDTO.Email, new List<string> { UserRole.Customer });
	}
}
