using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odering.Application.DTOs
{
    public class RoleResponseDTO
    {

        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
       // public string RoleName { get; internal set; }
        ////
        ///add RoleId and RoleName

    }
}
