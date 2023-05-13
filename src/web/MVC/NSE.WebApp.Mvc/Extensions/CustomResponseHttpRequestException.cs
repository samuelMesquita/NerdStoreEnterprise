using System;
using System.Net;
using System.Runtime.Serialization;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomResponseHttpRequestException : Exception
    {
        public HttpStatusCode StatusCode;
        public CustomResponseHttpRequestException(){}

        public CustomResponseHttpRequestException(string message, Exception innerException) 
            : base(message, innerException){}

        public CustomResponseHttpRequestException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
