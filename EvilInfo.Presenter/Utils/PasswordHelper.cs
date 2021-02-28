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
	}
}
