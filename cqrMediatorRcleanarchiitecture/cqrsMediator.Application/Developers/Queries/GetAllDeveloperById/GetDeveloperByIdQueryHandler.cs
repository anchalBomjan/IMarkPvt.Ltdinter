using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrsMediator.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using cqrsMediator.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Queries.GetAllDeveloperById
{
    public class GetDeveloperByIdQueryHandler(
     IApplicationDbContext context,
     IMapper mapper)
     : IRequestHandler<GetDeveloperByIdQuery, DeveloperDTO?>
    {
        public async Task<DeveloperDTO?> Handle(GetDeveloperByIdQuery request, CancellationToken ct)
        {
            return await context.Developers
                .Where(d => d.Id == request.Id)
                .ProjectTo<DeveloperDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ct);
        }
    }

}
