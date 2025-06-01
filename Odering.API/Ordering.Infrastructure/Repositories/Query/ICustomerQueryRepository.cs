using Odering.Core.Entities;
using Ordering.Infrastructure.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Query
{
    public interface ICustomerQueryRepository:IQueryRepository<Customer>
    {
        // Custom operation which is not generic

       
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<Customer>GetByIdAsync(Int64 id);

        Task<Customer> GetCustomerByEmail(string email);
    }
}
