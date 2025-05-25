using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public  class DeveloperCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int YearsOfExperience { get; set; }
        public decimal EstimateIncome { get; set; }


        public int? AddressId { get; set; } = null;
    }
}
