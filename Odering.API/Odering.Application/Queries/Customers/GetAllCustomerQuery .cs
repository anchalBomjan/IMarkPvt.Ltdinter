﻿using MediatR;
using Ordering.Core.Entities;
using Ordering.Core.Repositories.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Queries.Customers
{
    // Customer query with List<Customer> response
    public record GetAllCustomerQuery : IRequest<List<Customer>>
    {

    }

    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetAllCustomerHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            return (List<Customer>)await _customerQueryRepository.GetAllAsync();
        }
    }

}
