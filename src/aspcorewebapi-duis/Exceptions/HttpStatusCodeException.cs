using System;

namespace aspcorewebapi_duis.Exceptions
{
    public class HttpStatusCodeException : Exception
    {
        public virtual int StatusCode { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public HttpStatusCodeException(int statusCode)
        {
            this.StatusCode = statusCode;
        }

        public HttpStatusCodeException(string message, int statusCode) : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}