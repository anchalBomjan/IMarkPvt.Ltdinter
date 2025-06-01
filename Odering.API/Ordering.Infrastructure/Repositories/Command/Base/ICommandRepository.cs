using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories.Command.Base
{
    public  interface ICommandRepository<T> where T:class
    {

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entitiy);
        Task DeleteAsync(int id);
         
    }
}
