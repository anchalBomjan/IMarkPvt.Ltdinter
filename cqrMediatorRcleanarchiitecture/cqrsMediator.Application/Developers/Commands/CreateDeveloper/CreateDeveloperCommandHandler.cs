using cqrsMediator.Domain.Entities;
using MediatR;
using cqrsMediator.Application.Common.Interfaces;


namespace cqrsMediator.Application.Developers.Commands.CreateDeveloper
{

    public sealed class CreateDeveloperCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateDeveloperCommand, int>
    {
        public async Task<int> Handle(CreateDeveloperCommand request, CancellationToken ct)
        {


  
            var developer = new Developer
            {
                Name = request.Name,
                Email = request.Email,
                EstimateIncome = request.EstimateIncome,
                YearsOfExperience = request.YearsOfExperience,
                AddressId = request.AddressId,
            };
            await context.Developers.AddAsync(developer, ct);
            await context.SaveChangesAsync();
            return developer.Id;
        }
    }

}
