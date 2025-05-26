using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Address.Commands.CreateAddress
{
    public  record CreateAddressCommand(
        int Id,
        string Country
        
        
        );
    
}
