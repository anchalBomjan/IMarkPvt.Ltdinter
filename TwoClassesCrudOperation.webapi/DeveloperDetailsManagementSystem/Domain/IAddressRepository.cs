namespace DeveloperDetailsManagementSystem.Domain
{
    public interface IAddressRepository
    {
        Task <IEnumerable<Address>>GetAllAddressAsync(Address address);
        Task<Address?> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);

        Task DeleteAddressAsync(int id);





    }
}
