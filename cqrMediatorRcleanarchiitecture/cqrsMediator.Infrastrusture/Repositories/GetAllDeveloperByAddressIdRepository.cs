using cqrsMediator.Domain.Entities;
using cqrsMediator.Infrastrusture.Interfaces;
using cqrsMediator.Infrastrusture.Presistance;
using Microsoft.EntityFrameworkCore;
namespace cqrsMediator.Infrastrusture.Repositories
{
    public class GetAllDeveloperByAddressIdRepository(ApplicationDbContext context) : IDeveloperRepository
    {
        public async Task<IEnumerable<Developer>> GetAllDeveloperByAddressIdAsync(int addressId, CancellationToken ct)
        {
           return await  context.Developers
                .Include(d => d.Address)
                .Where(d => d.AddressId == addressId)
                .AsNoTracking()
                .ToListAsync(ct);

        }
    }
}
