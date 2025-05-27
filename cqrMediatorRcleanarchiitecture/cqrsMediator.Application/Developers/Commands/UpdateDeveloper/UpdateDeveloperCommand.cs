using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Commands.UpdateDeveloper
{
    public record UpdateDeveloperCommand(

       int Id,
        string Name,
        string Email,
        int YearsOfExperience,
        decimal EstimateIncome,
        int? AddressId
        

        ) : IRequest;

}
