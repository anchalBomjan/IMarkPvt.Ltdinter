using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.DTOs
{
    public class RoleResponseDTO
    {
        //   to avoid  errors in Ordering.Application.Queries.Role


        //public Int64 Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        //public string ContactNumber { get; set; }
        //public string Address { get; set; }
        public string Id { get; set; } // Changed from Int64 to string
        public string RoleName { get; set; } // Added missing property

      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
