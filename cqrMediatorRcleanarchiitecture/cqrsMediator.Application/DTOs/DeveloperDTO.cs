using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.DTOs
{
    public  class DeveloperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }= string.Empty;
        public decimal EstimateIncome { get; set; }
        public int YearsOfExperience { get; set; }
        // int? AddressId { get; set; }
      
        public AddressDTO ?Address { get; set; }



    }
}
