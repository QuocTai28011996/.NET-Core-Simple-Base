using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Data.EF.DTOs.Request;
using DemoAPI.Shared.APIResponse.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoAPI.API.Controllers.LoginController
{
	[Produces("application/json")]
	[Route("api/v1/Auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly Shared.Services.APIs.Authorization.IAuthService _authService;

		public AuthController(Shared.Services.APIs.Authorization.IAuthService authService)
		{
			_authService = authService;
		}

		/// <summary>
		/// Handles Register
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("register")]
		[Produces("application/json")]
		public RegisterResponse Register([FromBody]RegisterRequest request)
		{
			return _authService.Register(request);
		}

		/// <summary>
		/// login
		/// </summary>
		/// <returns>LoginResponse</returns>
		[HttpPost("login")]
		[Produces("application/json")]
		public LoginResponse Login([FromBody]LoginRequest request)
		{
			return _authService.Login(request);
		}
	}
}
