
namespace Common.Dtos
{
	public record LoginUserDto (string Email, string Password);
	public record RegisterUserDto(string Email, string Password, List<string> Roles);
	public record PaidCustomerDto(string Email);
	public record TokenUserDto(string Email, bool Save=true);
	public record AuthenticatedUserDto(string? AccessToken, string? UserName);
	public record SignUpUserDto(string Email, List<Claim> Roles);
	public class SignInModel
	{
		public bool isCustomer { get; set; }
	}
}
