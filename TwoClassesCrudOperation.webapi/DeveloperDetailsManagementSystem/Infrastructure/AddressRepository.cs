using DeveloperDetailsManagementSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeveloperDetailsManagementSystem.Infrastructure
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;
        
        public AddressRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public  async Task AddAddressAsync(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();
          
        }

      
        public  async Task<Address?> GetAddressByIdAsync(int id)
        {
             return  await _context.Addresses.FindAsync(id);
        }

        public  async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public  async Task UpdateAddressAsync(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                await _context.SaveChangesAsync();

            }
        }

        
        //public async Task<IEnumerable<Developer>> GetDevelopersByAddressIdAsync(int addressId)
        //{
        //    return await _context.Developers
        //        .Where(d => d.AddressId == addressId)
        //        .ToListAsync();
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}

      

        //public async Task<bool> SafeDeleteAdderessAsync(int id)
        //{
        //    var address = await _context.Addresses.FindAsync(id);
        //    if (address == null)
        //    {
        //        return false;
        //    }

        //    var developers = await _context.Developers
        //        .Where(d => d.AddressId == id)
        //        .ToListAsync();

        //    foreach (var developer in developers)
        //    {
        //        developer.AddressId = 0; // Make sure AddressId is nullable in the Developer entity
               
        //    }

        //    _context.Addresses.Remove(address);

        //    await _context.SaveChangesAsync();
        //    return true;
        //}

    }
}
