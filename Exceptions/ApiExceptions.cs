using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace Vultr.API.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException()
        {
            _errors = new Dictionary<int, string>() { { 401, "Access Denied" }, { 404, "Not Found" }, { 429, "Rate Limit Exceeded" } };
        }

        public ApiException(HttpStatusCode statusCode)
        {
            _errors = new Dictionary<int, string>() { { 401, "Access Denied" }, { 404, "Not Found" }, { 429, "Rate Limit Exceeded" } };
            StatusCode = statusCode;
        }

        private readonly IDictionary<int, string> _errors;

        public HttpStatusCode StatusCode { get; set; }

        public override string Message
        {
            get
            {
                return _errors.ContainsKey(Conversions.ToInteger(StatusCode)) ? _errors[Conversions.ToInteger(StatusCode)] : "Unknown API error";
            }
        }
    }
}