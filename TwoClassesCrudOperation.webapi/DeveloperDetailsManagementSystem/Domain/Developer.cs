namespace DeveloperDetailsManagementSystem.Domain
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal EstimateIncome { get; set; }

        // Foreign key of Address
        public int? AddressId { get; set; }

        // navigate the property of Address
        public Address Address { get; set; }



    }
}
