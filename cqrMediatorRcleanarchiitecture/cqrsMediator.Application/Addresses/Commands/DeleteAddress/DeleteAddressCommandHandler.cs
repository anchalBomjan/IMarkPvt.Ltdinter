
using cqrsMediator.Application.Common.Interfaces;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.DeleteAddress
{
    public sealed class DeleteAddressCommandHandler(IApplicationDbContext context)
        :IRequestHandler<DeleteAddressCommand>

    {
        public async Task Handle(DeleteAddressCommand request, CancellationToken ct)
        {
            //var address = await context.Addresses.FindAsync(request);
            //if (address != null)
            //{
            //    context.Addresses.Remove(address);
            //    await context.SaveChangesAsync();
            //}
            // find by id not by object body so do this
            var address = await context.Addresses.FindAsync(new object[] { request.id },ct);

            if (address != null)
            {
                context.Addresses.Remove(address);
                await context.SaveChangesAsync(ct);
            }
            



        }
    }
}
