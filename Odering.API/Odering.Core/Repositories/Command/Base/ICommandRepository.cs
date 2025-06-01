using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odering.Core.Repositories.Command.Base
{
    public  interface ICommandRepository<T> where T : class
    {
        Task<T> AddAsync(T entitiy);
        Task UpdateAsync(T entitiy);
        Task DeleteAsync(T entitiy);

    }
}
