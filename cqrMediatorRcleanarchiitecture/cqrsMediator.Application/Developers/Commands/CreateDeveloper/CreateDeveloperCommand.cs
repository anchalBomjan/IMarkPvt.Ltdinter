using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Commands.CreateDeveloper
{
    public record CreateDeveloperCommand(
        string Name,
        string Email,
        int YearsOfExperience,
        decimal EstimateIncome,
        int? AddressId
    ) : IRequest<int>;





}
