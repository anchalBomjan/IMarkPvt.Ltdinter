using MediatR;
using Odering.Application.DTOs;
using Odering.Core.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odering.Application.Commands.Customers.Create
{
    // Customer create command with CustomerResponse
    public class CreateCustomerCommand : IRequest<CustomerResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateCustomerCommand()
        {
            this.CreatedDate = DateTime.Now;
        }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;
        public CreateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }
        public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);

            if (customerEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newCustomer = await _customerCommandRepository.AddAsync(customerEntity);
            var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(newCustomer);
            return customerResponse;
        }
    }
}
