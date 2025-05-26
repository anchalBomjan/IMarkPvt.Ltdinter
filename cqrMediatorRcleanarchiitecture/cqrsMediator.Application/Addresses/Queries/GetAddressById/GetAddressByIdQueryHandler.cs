using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrsMediator.Application.DTOs;
using cqrsMediator.Infrastrusture.Presistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Queries.GetAddressById
{
    public sealed class GetAddressByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
        :IRequestHandler<GetAddressByIdQuery,AddressDTO>
    {
        public async Task<AddressDTO> Handle(GetAddressByIdQuery request, CancellationToken ct)
        {

            

             return await context.Addresses  // Changed from Developers to Addresses
               .Where(a => a.Id == request.Id)
               .ProjectTo<AddressDTO>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(ct);


        }
    }
}
