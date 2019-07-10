using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using DemoAPI.Data;
using DemoAPI.Data.EF.DTOs.Request;
using DemoAPI.Data.EF.Helpers;
using DemoAPI.Data.Models;
using DemoAPI.Data.Models.Database.Authorization;
using DemoAPI.Service.Services.EntityService;

//using Giveaway.DataLayers.Models.IntermediateModels;

namespace DemoAPI.Service.Services.Authorization
{
	public interface IAuthService : IEntityService<User>
	{
		ResponseMessage ValidateLogin(LoginRequest request);

		ResponseMessage ValidateRegister(RegisterRequest model);

		User CreateUser(RegisterRequest model);

		//User CreateUser(FacebookAccount model);

		(byte[] Salt, byte[] Hash) GenerateSecurePassword(string rawPassword);
	}

	public class UserService : EntityService<User>, IAuthService
	{
		#region Private Fields
		private const string DefaultUserPassword = "user@123";
		private const string UsernamePattern = "[a-zA-Z0-9_]{1,20}";
		#endregion

		#region Constructor

		public UserService()
		{
		}

		#endregion

		#region Methods

		public ResponseMessage ValidateLogin(LoginRequest request)
		{
			if (string.IsNullOrEmpty(request.UserName))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Vui lòng nhập tên tài khoản.");
			}

			if (string.IsNullOrEmpty(request.Password))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Vui lòng nhập mật khẩu.");
			}

			var user = FirstOrDefault(x =>  x.DisplayName == request.UserName);

			if (user == null)
			{
				return new ResponseMessage(HttpStatusCode.NotFound, "Tài khoản không tồn tại.");
			}

			var hash = HashHelper.ComputeHash(request.Password, user.PasswordSalt);

			if (!user.PasswordHash.SequenceEqual(hash))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Mật khẩu không chính xác.");
			}

			return new ResponseMessage(HttpStatusCode.OK, data: user);
		}

		public ResponseMessage ValidateRegister(RegisterRequest model)
		{
			if (string.IsNullOrEmpty(model.Password))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Vui lòng nhập mật khẩu.");
			}


			if (string.IsNullOrEmpty(model.PasswordRetype))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Vui lòng nhập lại mật khẩu.");
			}

			if (model.PasswordRetype != model.Password)
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Nhập lại mật khẩu không chính xác.");
			}


			if (string.IsNullOrEmpty(model.Username))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Vui lòng nhập tên tài khoản.");
			}

			if (!IsUserNameFormatValid(model.Username))
			{
				return new ResponseMessage(HttpStatusCode.BadRequest, "Tên tài khoản từ 6-20 ký tự và chỉ bao gồm các ký tự A-Z & 0-9 and _.");
			}

			return new ResponseMessage(HttpStatusCode.OK);
		}

		public User CreateUser(RegisterRequest model)
		{
			var securePassword = GenerateSecurePassword(model.Password);

			return new User
			{
				DisplayName = model.Username,
				PasswordSalt = securePassword.Salt,
				PasswordHash = securePassword.Hash,
				CreatedTime = DateTimeOffset.Now,
				UpdatedTime = DateTimeOffset.Now,
				LastLogin = DateTimeOffset.Now,
				Id = Guid.NewGuid()
			};
		}

		public (byte[] Salt, byte[] Hash) GenerateSecurePassword(string rawPassword)
		{
			var passwordSalt = HashHelper.GenerateSalt();
			var passwordHash = HashHelper.ComputeHash(rawPassword, passwordSalt);

			return (passwordSalt, passwordHash);
		}

		private bool IsUserNameFormatValid(string userName)
		{
			return Regex.IsMatch(userName, UsernamePattern);
		}

		#endregion
	}
}
