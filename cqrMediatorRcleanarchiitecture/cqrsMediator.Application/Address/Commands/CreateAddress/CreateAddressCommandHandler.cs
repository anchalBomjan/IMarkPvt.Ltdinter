using cqrsMediator.Infrastrusture.Presistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Address.Commands.CreateAddress
{
    public sealed class CreateAddressCommandHandler(ApplicationDbContext context):
        IRequestHandler<CreateAddressCommand,int>
    {
        public async Task<int> Handle(CreateAddressCommand  request,CancellationToken ct)
        {

            var developer = new Developer
            {
                Country=request.Country
               
            };
            await context.Developers.AddAsync(developer, ct);
            await context.SaveChangesAsync(ct);
            return developer.Id;
        }


    }
}
