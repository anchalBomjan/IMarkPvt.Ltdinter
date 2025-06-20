using cqrsMediator.Application.Common.Exceptions;
using cqrsMediator.Domain.Entities;
using cqrsMediator.Application.Common.Interfaces;

using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.UpdateAddress
{
    public sealed  class UpdateAddressCommandHandler(IApplicationDbContext context)
        :IRequestHandler<UpdateAddressCommand>
    {
        public async Task Handle(UpdateAddressCommand request,CancellationToken ct)
        {

            var address = await context.Addresses.FirstOrDefaultAsync(d => d.Id == request.Id, ct);
          

            if (address is null)
            {
                throw new NotFoundException(nameof(address),request.Id);
            }
          

            address.Country = request.Country;
            await context.SaveChangesAsync(ct);
        }
    }
}
