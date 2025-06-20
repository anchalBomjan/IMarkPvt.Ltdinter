using cqrsMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Developer> Developers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
