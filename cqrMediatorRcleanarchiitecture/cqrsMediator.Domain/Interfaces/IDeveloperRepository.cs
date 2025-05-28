using cqrsMediator.Domain.Entities;

namespace cqrsMediator.Domain.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDeveloperByAddressIdAsync(int addressId, CancellationToken ct);
    }
}
