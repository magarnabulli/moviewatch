namespace UsersDb.Services
{
	public interface IUserService
	{
		Task<User?> GetUserAsync(LoginUserDto loginUser);
		Task<User?> GetUserAsync(string email);
	}
}