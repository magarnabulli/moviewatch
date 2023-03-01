namespace UsersDb.Contexts
{
	public class UserContext : IdentityDbContext<User>
	{
		public UserContext(DbContextOptions<UserContext> options): base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
