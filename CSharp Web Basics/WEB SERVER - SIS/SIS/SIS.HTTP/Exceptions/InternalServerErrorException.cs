using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public const HttpResponseStatusCode HttpStatusCode = HttpResponseStatusCode.InternalServerError;

        public override string Message => "The Server has encountered an error.";
    }
}
