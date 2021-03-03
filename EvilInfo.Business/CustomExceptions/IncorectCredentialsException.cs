using System;

namespace EvilInfo.Business.CustomExceptions
{
	public class IncorectCredentialsException : Exception
	{
		public IncorectCredentialsException(string message)
			: base(message)
		{

		}
	}
}
