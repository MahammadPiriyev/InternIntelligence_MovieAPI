using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Domain.Identity;
using MovieAPI.Domain.Services.Abstract;

namespace MovieAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register(Login user)
		{
			if (await _authService.Register(user))
			{
				return Ok(new {message = "New user has successfully created!"});
			}
			return BadRequest(new { message = "User could not be created!" });
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(Login user)
		{
			if (await _authService.Login(user))
			{
				var tokenString = _authService.GenerateTokenString(user);
				return Ok(tokenString);
			}
			return BadRequest(new { message = "User could not be signed in! (username or password is not correct)" });
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await _authService.Logout();
			return Ok(new { message = "Logged out successfully" });
		}
	}
}
