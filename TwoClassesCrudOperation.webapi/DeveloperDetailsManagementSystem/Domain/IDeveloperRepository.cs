namespace DeveloperDetailsManagementSystem.Domain
{
    public interface IDeveloperRepository
    {

        Task<IEnumerable<Developer>> GetAllDeveloperAsync();

        Task<Developer> GetDeveloperByIdAsync(int id);
        Task AddDeveloperAsync(Developer developer);
        Task UpdateDeveloperAsync(Developer developer);
        Task DeleteDeveloperAsync(int id);
    }
}
