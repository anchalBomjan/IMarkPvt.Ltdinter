using cqrsMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using cqrsMediator.Application.Common.Interfaces;

namespace cqrsMediator.Infrastrusture.Repositories
{
    public class GetAllDeveloperByAddressIdRepository(IApplicationDbContext context) : IDeveloperRepository
    {
        public async Task<IEnumerable<Developer>> GetAllDeveloperByAddressIdAsync(int addressId, CancellationToken ct)
        {
            return await context.Developers
                 .Include(d => d.Address)
                 .Where(d => d.AddressId == addressId)
                 .AsNoTracking()
                 .ToListAsync(ct);

        }
    }
}