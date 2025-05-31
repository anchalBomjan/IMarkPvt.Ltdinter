using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.CreateAddress
{
    sealed class CreateAddressCommandValidator:AbstractValidator<CreateAddressCommand>
    {

        private static readonly HashSet<string> BlockedCountries = new()
    {
        "Australia",
        "North Korea",
        "Belarus"
    };
     
        public CreateAddressCommandValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Must(country => !BlockedCountries.Contains(country.Trim(), StringComparer.OrdinalIgnoreCase))
                .WithMessage("Addresses from Australia, North Korea, or Belarus are not allowed.");
        }
    }
}
