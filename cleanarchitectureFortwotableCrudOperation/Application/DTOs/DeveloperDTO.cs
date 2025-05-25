using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public int YearsOfExperience { get; set; }
        public decimal EstimateIncome { get; set; }
        // Foreign key of Address

        public int? AddressId { get; set; }

        // navigate the property of Address
        public AddressDTO ? Address { get; set; }
    }
}
