using Odering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Query.Base
{
    public  interface ICustomerQueryRepository
    {
        //Customer operation which is not generic

        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetCustomerByEmail(string email);

    }
}
