using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Commands.CreateAddress
{
    public  record CreateAddressCommand(
        int Id,
        string Country
        ):IRequest<int>;
    
}
