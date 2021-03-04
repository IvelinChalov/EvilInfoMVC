using System;

namespace EvilInfo.Presentation.CustomExceptions
{
	public class IncorectCredentialsException : Exception
	{
		public IncorectCredentialsException(string message)
			: base(message)
		{

		}
	}
}
