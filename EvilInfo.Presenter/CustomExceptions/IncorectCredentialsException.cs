using System;

namespace EvilInfo.Presentation.CustomExceptions
{
	class IncorectCredentialsException : Exception
	{
		public IncorectCredentialsException(string message)
			: base(message)
		{

		}
	}
}
