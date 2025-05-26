using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Domain.Entities
{
    public  class Developer
    {

        


        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Email { get; set; } = string.Empty;   
        public int YearsOfExperience { get; set; }
        public decimal EstimateIncome { get; set; }

        // Foreign key of Address

        // this allows to store null value if  related adderessId  delelet in Adderess Tbl 
        public int? AddressId { get; set; }

        // navigate the property of Address
        public Address Address { get; set; }

    }
}
