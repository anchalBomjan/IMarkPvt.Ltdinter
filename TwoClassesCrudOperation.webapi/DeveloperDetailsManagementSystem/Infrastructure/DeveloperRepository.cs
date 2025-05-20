using DeveloperDetailsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeveloperDetailsManagementSystem.Infrastructure
{
    public class DeveloperRepository : IDeveloperRepository
    {

        private readonly ApplicationDbContext _context;
        public DeveloperRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task AddDeveloperAsync(Developer developer)
        {
            await _context.AddAsync(developer);
            await _context.SaveChangesAsync();

        }

        public async  Task DeleteDeveloperAsync(int id)
        {
            var developer =  await _context.Developers.FindAsync(id);
            if(developer != null)
            {
                  _context.Developers.Remove(developer);
                   await _context.SaveChangesAsync();

            }
            
        }

        public async  Task<IEnumerable<Developer>> GetAllDeveloperAsync()
        {
            return await _context.Developers.ToListAsync();

        }

        public  async Task<Developer?> GetDeveloperByIdAsync(int id)
        {
             return  await _context.Developers.FindAsync(id);

         
          

        }

        public async  Task UpdateDeveloperAsync(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();
            
        }
    }
}
