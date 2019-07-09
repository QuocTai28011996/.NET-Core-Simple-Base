using DemoAPI.Data.EF.DTOs.Request;
using DemoAPI.Shared.APIResponse.Login;

namespace DemoAPI.Shared.Services.APIs.Authorization
{
	public interface IAuthService
	{
		RegisterResponse Register(RegisterRequest request);
		LoginResponse Login(LoginRequest request);
	}
}