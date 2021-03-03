using System;

namespace EvilInfo.CustomExceptions
{
	public class IncorectCredentialsException : Exception
	{
		public IncorectCredentialsException(string message)
			: base(message)
		{

		}
	}
}
