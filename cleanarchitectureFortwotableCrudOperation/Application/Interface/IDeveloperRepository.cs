using Domain.Entities;
namespace Application.Interface
{
    public  interface IDeveloperRepository
    {

        Task<IEnumerable<Developer>> GetAllAsync();
        Task<Developer?> GetByIdAsync(int id);
        Task AddAsync(Developer developer);
        Task UpdateAsync(Developer developer);
        Task DeleteAsync(int id);
    }
}
