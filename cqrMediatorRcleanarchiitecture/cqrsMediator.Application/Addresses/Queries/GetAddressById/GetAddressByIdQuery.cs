using cqrsMediator.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Addresses.Queries.GetAddressById
{
    public record GetAddressByIdQuery(int Id):IRequest< AddressDTO>;
   
}
