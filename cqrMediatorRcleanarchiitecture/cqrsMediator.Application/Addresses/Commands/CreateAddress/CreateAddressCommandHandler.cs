using cqrsMediator.Domain.Entities;
using MediatR;
using cqrsMediator.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.CreateAddress
{
    public sealed class CreateAddressCommandHandler(IApplicationDbContext context)
        :IRequestHandler<CreateAddressCommand,int>
    {
        public async Task<int> Handle(CreateAddressCommand request, CancellationToken ct)
        {
            var address = new Address
            {
                Country = request.Country
            };
            
            await context.Addresses.AddAsync(address, ct);
            await context.SaveChangesAsync();

            return address.Id;
        }

    }
}
