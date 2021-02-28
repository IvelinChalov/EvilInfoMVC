using System.Text.RegularExpressions;

namespace EvilInfo.Presentation.Utils
{
	static class ValidatorHelper
	{
		public static bool IsStrigValid(string input)
		{
			bool isValid = false;
			string validCharecterPattern = @"^[a-z A-Z]+$";

			isValid = Regex.IsMatch(input, validCharecterPattern);
			return isValid;
		}


	}
}
