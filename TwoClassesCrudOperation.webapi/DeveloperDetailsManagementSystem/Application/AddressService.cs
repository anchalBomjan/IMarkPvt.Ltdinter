using DeveloperDetailsManagementSystem.Application.DTOs;
using DeveloperDetailsManagementSystem.Domain;

namespace DeveloperDetailsManagementSystem.Application
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressrepository)
        {
            _addressRepository= addressrepository;

        }

        public async Task <IEnumerable<AddressDTO>> GetAllAddressAsync()
        {
            var addresses = await _addressRepository.GetAllAddressAsync();
            return addresses.Select(a=> new AddressDTO
            {
                Id = a.Id,
                Country = a.Country,
            }).ToList();
           

        }
        public async Task<AddressDTO?> GetAddressById(int id)
        {
            var address= await _addressRepository.GetAddressByIdAsync(id);
            if (address == null) { return null; }
            return   new AddressDTO
            {
                Id = address.Id,
                Country = address.Country,

            };
          
        }

        public async Task AddAddressAsync(CreateAdderessDTO addressdto)
        {
            var address = new Address
            {
              
                Country = addressdto.Country,

            };
            await _addressRepository.AddAddressAsync(address);

        }
        public async Task DeleteAddressAsync(int id)
        {
          await _addressRepository.DeleteAddressAsync(id);
        }

        public async Task UpdateAddressAsync( int id,CreateAdderessDTO addressdto)
        {
            var address = await _addressRepository.GetAddressByIdAsync( id);
            if (address == null) { throw new Exception("Not found"); }


            address.Country = addressdto.Country;
            await _addressRepository.UpdateAddressAsync(address);
            
           

        }
    }
}
