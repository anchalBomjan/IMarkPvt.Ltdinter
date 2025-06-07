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
           
       
            if (request.Id <= 0)
            {
                throw new NotFoundException(nameof(Developer), request.Id);
            }

            // 2. Check if developer exists
            var developer = await context.Developers
                .FirstOrDefaultAsync(d => d.Id == request.Id, ct);

            if (developer is null)
            {
                throw new NotFoundException(nameof(Developer), request.Id);
            }

            // 3. Update only mutable properties
            developer.Name = request.Name;
            developer.Email = request.Email;

            developer.YearsOfExperience = request.YearsOfExperience;
            developer.EstimateIncome = request.EstimateIncome;
            developer.AddressId = request.AddressId; // Direct assignment without validation

            // 4. Save changes
            await context.SaveChangesAsync(ct);



        }

    }


}
