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

            if (developer != null)
            {
                developer.Id = request.Id;
                developer.Name = request.Name;
                developer.Email = request.Email;
                developer.YearsOfExperience = request.YearsOfExperience;
                developer.EstimateIncome = request.EstimateIncome;
                developer.AddressId = request.AddressId;

                await context.SaveChangesAsync(ct);
            }






        }

    }


}
