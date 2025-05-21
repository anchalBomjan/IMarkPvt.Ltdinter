namespace DeveloperDetailsManagementSystem.Application.DTOs
{
    public class DeveloperCreateDTO
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal EstimateIncome { get; set; }

        // only accept addressId
        public int? AddressId { get; set; }
    }
}
