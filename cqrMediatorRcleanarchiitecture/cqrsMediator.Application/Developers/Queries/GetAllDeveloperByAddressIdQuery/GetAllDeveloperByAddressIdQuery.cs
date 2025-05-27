using cqrsMediator.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Queries.GetAllDeveloperByAddressIdQuery
{
    //public record GetAllDeveloperByAddressIdQuery(int AddressId):IRequest< IEnumerable<DeveloperDTO>>;

    public record GetAllDeveloperByAddressIdQuery(int AddressId)
        : IRequest<IEnumerable<DeveloperDTO>>;

}
