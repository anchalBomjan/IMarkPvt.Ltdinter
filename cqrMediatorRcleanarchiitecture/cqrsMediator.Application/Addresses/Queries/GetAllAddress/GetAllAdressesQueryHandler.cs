using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrsMediator.Application.DTOs;
using cqrsMediator.Application.Common.Interfaces;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Queries.GetAllAddress
{

        public sealed class GetAllAddressesQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
            : IRequestHandler<GetAllAddressesQuery, List<AddressDTO>>
        {
            public async Task<List<AddressDTO>> Handle(
                GetAllAddressesQuery request,
                CancellationToken ct)
            {
                return await context.Addresses
                    .ProjectTo<AddressDTO>(mapper.ConfigurationProvider)
                    .ToListAsync(ct);
            }
        }
    
}
