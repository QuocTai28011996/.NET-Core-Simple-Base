using System;
using System.Linq;
using System.Net;
using DemoAPI.Data;
using DemoAPI.Data.EF.DTOs.Request;
using DemoAPI.Data.EF.Exceptions;
using DemoAPI.Data.Models.Database.Authorization;
using DemoAPI.Shared.APIResponse.Login;
using DemoAPI.Shared.Extensions;
using DemoAPI.Shared.Helpers;
using DemoAPI.Util.Constants;
using DbService = DemoAPI.Service.Services.Authorization;

namespace DemoAPI.Shared.Services.APIs.Authorization
{
	/// <inheritdoc />
	public class AuthService : IAuthService
	{
		#region Private Fields

		private readonly DbService.IAuthService _authService;

		#endregion

		#region Constructor

		public AuthService(DbService.IAuthService authService)
		{
			_authService = authService;
		}

		#endregion

		#region Methods

		public RegisterResponse Register(RegisterRequest request)
		{
			var resultRegister = _authService.ValidateRegister(request);

			if (resultRegister.StatusCode != HttpStatusCode.OK)
			{
				throw resultRegister.ToException();
			}

			var user = _authService.CreateUser(request);
			user.EntityStatus = EntityStatus.Activated;
			var newUser = _authService.Where(x => x.DisplayName.Equals(request.Username));
			if (!newUser.Any())
			{
				var createdUser = _authService.Create(user, out var isSaved);

				if (!isSaved)
				{
					throw new SystemException("Internal Error");
				}

				return GenerateRegisterResponse(createdUser);
			}
			else
			{
				throw new BadRequestException(CommonConstant.Error.DuplicatedUserName);
			}
		}

		public LoginResponse Login(LoginRequest request)
		{
			var validateResult = _authService.ValidateLogin(request);

			if (validateResult.StatusCode != HttpStatusCode.OK)
			{
				throw validateResult.ToException();
			}

			return GenerateLoginResponse(validateResult.Data as User);
		}

		#endregion

		#region Private Helpers

		private RegisterResponse GenerateRegisterResponse(User user)
		{
			var token = JwtHelper.CreateToken(user.Id, user.DisplayName);

			return new RegisterResponse()
			{
				Token = token,
				Profile = GenerateUserProfileResponse(user)
			};
		}

		private UserProfileResponse GenerateUserProfileResponse(User user)
		{
			var response = new UserProfileResponse()
			{
				Id = user.Id,
				DisplayName = user.DisplayName
			};

			return response;
		}

		private LoginResponse GenerateLoginResponse(User user)
		{
			var token = JwtHelper.CreateToken(user.Id, user.DisplayName);

			var response = new LoginResponse
			{
				TokenType = token.Type,
				Token = token.AccessToken,
				ExpiresIn = token.Expires,
			};

			return response;
		}
		#endregion
	}
}
