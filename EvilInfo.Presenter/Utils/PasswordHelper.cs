using System;
using System.Security.Cryptography;
using System.Text;

namespace EvilInfo.Presenter.Utils
{
	public static class PasswordHelper
	{
		public static string HashPassword(string password)
		{
			var provider = new SHA1CryptoServiceProvider();
			var encoding = new UnicodeEncoding();
			return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
		}

		public static bool IsSame(string first, string second)
		{
			return string.Equals(first, second);
		}
	}
}
