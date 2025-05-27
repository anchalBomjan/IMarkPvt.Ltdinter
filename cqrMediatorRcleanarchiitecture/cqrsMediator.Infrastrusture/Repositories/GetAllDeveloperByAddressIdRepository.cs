using cqrsMediator.Domain.Entities;
using cqrsMediator.Domain.Interfaces;
using cqrsMediator.Infrastrusture.Presistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
