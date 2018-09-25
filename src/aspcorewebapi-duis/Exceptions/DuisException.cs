using System;

namespace aspcorewebapi_duis.Exceptions
{
    public class DuisException : HttpStatusCodeException
    {
        public DuisException(string message) : base(message, 401)
        {
        }
    }
}