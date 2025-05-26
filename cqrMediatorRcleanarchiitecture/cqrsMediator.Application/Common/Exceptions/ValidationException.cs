using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Common.Exceptions
{// Application/Common/Exceptions/ValidationException.cs


    //public class ValidationException : Exception
    //{
    //    public IDictionary<string, string[]> Errors { get; }

    //    public ValidationException()
    //        : base("Validation failures occurred.")
    //    {
    //        Errors = new Dictionary<string, string[]>();
    //    }

    //    public ValidationException(IEnumerable<ValidationFailure> failures)
    //        : this()
    //    {
    //        Errors = failures
    //            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
    //            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    //    }
    //}

    /// you have to install FluentValidation packages
    


}
