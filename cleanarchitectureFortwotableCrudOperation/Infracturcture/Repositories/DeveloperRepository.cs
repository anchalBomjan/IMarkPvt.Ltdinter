using Application.Interface;
using Domain.Entities;
using Infracturcture.Presistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasturcture.Repositories
{
    public  class DeveloperRepository:IDeveloperRepository
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

        public async Task DeleteDeveloperAsync(int id)
        {
            var developer = await _context.Developers.FindAsync(id);
            if (developer != null)
            {
                _context.Developers.Remove(developer);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<IEnumerable<Developer>> GetAllDeveloperAsync()
        {
            return await _context.Developers
                .Include(d => d.Address)
                .ToListAsync();

        }

        public async Task<Developer?> GetDeveloperByIdAsync(int id)
        {
            return await _context.Developers
               .Include(d => d.Address)
               .FirstOrDefaultAsync(d => d.Id == id);





        }

        public async Task UpdateDeveloperAsync(Developer developer)
        {
            _context.Developers.Update(developer);
            await _context.SaveChangesAsync();

        }



    }
}
