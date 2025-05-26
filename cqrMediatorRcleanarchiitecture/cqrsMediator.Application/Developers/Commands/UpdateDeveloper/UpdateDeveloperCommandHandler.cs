using cqrsMediator.Application.Common.Exceptions;
using cqrsMediator.Domain.Entities;
using cqrsMediator.Infrastrusture.Presistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace cqrsMediator.Application.Developers.Commands.UpdateDeveloper
{
    public sealed class UpdateDeveloperCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateDeveloperCommand>
    {

        public async Task Handle(UpdateDeveloperCommand request, CancellationToken ct)
        {
            var developer = await context.Developers.FirstOrDefaultAsync(d => d.Id == request.Id, ct);

           
            if(developer is null)
            {
                throw new NotFoundException(nameof(Developer), request.Id);
            }
                developer.Id = request.Id;
                developer.Name = request.Name;
                developer.Email = request.Email;
                developer.YearsOfExperience = request.YearsOfExperience;
                developer.EstimateIncome = request.EstimateIncome;
                developer.AddressId = request.AddressId;


            // Verify Address exists if AddressId is provided
            //if (request.AddressId.HasValue)
            //{
            //    var addressExists = await context.Addresses
            //        .AnyAsync(a => a.Id == request.AddressId.Value, ct);

            //    if (!addressExists)
            //    {
            //        throw new NotFoundException(nameof(Address), request.AddressId.Value);
            //    }
            //}

            context.Developers.Add(developer);

            await context.SaveChangesAsync(ct);
            






        }

    }


}
