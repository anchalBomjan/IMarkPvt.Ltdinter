using AutoMapper;
using cqrsMediator.Application.DTOs;
using cqrsMediator.Application.Common.Interfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Queries.GetAllDeveloperByAddressIdQuery
{
    public class GetAllDeveloperByAddressIdQueryHandler(IDeveloperRepository repository,IMapper mapper)
     : IRequestHandler<GetAllDeveloperByAddressIdQuery, IEnumerable<DeveloperDTO>>

    {
        public async Task<IEnumerable<DeveloperDTO>> Handle(GetAllDeveloperByAddressIdQuery request, CancellationToken ct)
        {
            var developers= await repository.GetAllDeveloperByAddressIdAsync(request.AddressId, ct);

            return mapper.Map<IEnumerable<DeveloperDTO>>(developers);
        }
    }
}
