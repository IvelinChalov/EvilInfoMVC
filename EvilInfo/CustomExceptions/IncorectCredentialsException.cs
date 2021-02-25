using System;
using System.Collections.Generic;
using System.Text;

namespace EvilInfo.CustomExceptions
{
    class IncorectCredentialsException : Exception
    {
        public IncorectCredentialsException(string message)
            : base(message)
        {

        }
    }
}
