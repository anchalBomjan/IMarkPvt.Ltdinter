using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.UpdateAddress
{
    public record UpdateAddressCommand(
        int Id,

        string Country
        
        ):IRequest;
    
}
