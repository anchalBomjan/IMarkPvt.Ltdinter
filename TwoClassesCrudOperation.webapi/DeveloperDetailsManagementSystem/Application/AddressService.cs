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
    }
}
