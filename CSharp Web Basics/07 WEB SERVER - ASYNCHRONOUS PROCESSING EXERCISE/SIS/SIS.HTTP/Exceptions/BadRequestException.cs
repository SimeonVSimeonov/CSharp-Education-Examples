using SIS.HTTP.Enums;
using System;

namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        public const HttpResponseStatusCode HttpStatusCode = HttpResponseStatusCode.BadRequest;

        public override string Message => "The Request was malformed or contains unsupported elements.";
    }
}
