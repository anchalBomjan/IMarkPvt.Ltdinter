using System.Runtime.CompilerServices;

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

        // this allows to store null value if  related adderessId  delelet in Adderess Tbl 
        public int? AddressId { get; set; }

        // navigate the property of Address
        public Address Address { get; set; }



    }
}
