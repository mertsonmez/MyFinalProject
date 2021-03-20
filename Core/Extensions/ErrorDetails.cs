using FluentValidation.Results;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }       

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }


}
