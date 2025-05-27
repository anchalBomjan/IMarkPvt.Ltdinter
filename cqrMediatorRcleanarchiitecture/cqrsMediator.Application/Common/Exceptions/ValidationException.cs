using Microsoft.IdentityModel.Tokens;
namespace cqrsMediator.Application.Common.Exceptions
{// Application/Common/Exceptions/ValidationException.cs


    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
            : base("Validation failures occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.Property, e => e.Error)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }

    /// you have to install FluentValidation packages



}
