using cqrsMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Infrastrusture.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDeveloperByAddressIdAsync(int addressId, CancellationToken ct);
    }

}
