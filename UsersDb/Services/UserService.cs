namespace UsersDb.Services
{
	public class UserService : IUserService
	{
		private readonly UserManager<User> _manager;

		public UserService(UserManager<User> manager) => _manager = manager;

		public async Task<User?> GetUserAsync(string email)
		{
			try
			{
				return await _manager.FindByEmailAsync(email);
			}
			catch
			{

				return default;
			}
		}

		public async Task<User?> GetUserAsync(LoginUserDto loginUser)
		{
			try
			{
				var user = await _manager.FindByEmailAsync(loginUser.Email);
				if (user == null) return default;

				var hasher = new PasswordHasher<User>();
				var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);

				if (result == PasswordVerificationResult.Success) { return user; }
			}
			catch
			{
			}
			return default;
		}

	}
}
