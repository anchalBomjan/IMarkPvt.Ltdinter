using Odering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odering.Core.Repositories.Query
{
    public interface ICustomerQueryRepository
    {
        //Custom operation which is not generic
         Task<IReadOnlyList<Customer>> GetAllAsync();

        Task<Customer>GetByIdAsync(int id);
        Task<Customer>GetCustomerByEmail(string email);
    }
}
