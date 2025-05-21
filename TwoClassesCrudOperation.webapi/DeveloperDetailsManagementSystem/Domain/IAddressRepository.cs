namespace DeveloperDetailsManagementSystem.Domain
{
    public interface IAddressRepository
    {
        Task <IEnumerable<Address>>GetAllAddressAsync();
        Task<Address?> GetAddressByIdAsync(int id);
        Task AddAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);

        // Extra helper
        //Task<IEnumerable<Developer>> GetDevelopersByAddressIdAsync(int addressId);
        //Task SaveChangesAsync();
        //Task<bool>SafeDeleteAdderessAsync(int id);// Custom: sets AddressId to null before delete




    }
}
