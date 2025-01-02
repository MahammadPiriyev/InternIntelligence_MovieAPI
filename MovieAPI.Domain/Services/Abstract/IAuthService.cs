using MovieAPI.Domain.Identity;

namespace MovieAPI.Domain.Services.Abstract
{
	public interface IAuthService
	{
		string GenerateTokenString(Login user);
		Task<bool> Login(Login user);
		Task Logout();
		Task<bool> Register(Login user);
	}
}