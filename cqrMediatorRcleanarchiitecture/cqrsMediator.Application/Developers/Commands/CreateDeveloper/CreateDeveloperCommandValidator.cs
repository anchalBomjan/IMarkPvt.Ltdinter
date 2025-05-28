using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Commands.CreateDeveloper
{

    public class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand>
    {
        public CreateDeveloperCommandValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Must(BeAValidEmail).WithMessage("Invalid email format.");

            RuleFor(x => x.EstimateIncome)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.YearsOfExperience)
                .GreaterThanOrEqualTo(0);
        }

        private bool BeAValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;

            }
            catch
            {
                return false;
            }
        }
    }
}
