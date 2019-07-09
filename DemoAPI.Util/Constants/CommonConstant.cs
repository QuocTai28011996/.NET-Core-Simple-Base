namespace DemoAPI.Util.Constants
{
	public static class CommonConstant
	{
		public class Error
		{
			public static string DuplicatedUserName = "This UserName has been taken, please choose another one!";
			public const string BadRequest = "Bad Request";
			public const string NotFound = "Not Found";
			public const string InternalServerError = "Internal Server Error";
			public static string BlockedUser = "UserHasBeenBlocked";
			public static string InvalidInput = "Invalid Input";
			public static string ServiceUnavailable = "Api version of the application is deprecated, please update the application to a newer version";
		}
	}
}