// Application/Developers/Queries/GetAllDevelopers/GetAllDevelopersQueryHandler.cs
using AutoMapper;
using AutoMapper.QueryableExtensions;
using cqrsMediator.Application.Common.Exceptions;
using cqrsMediator.Application.Common.Mappings;
using cqrsMediator.Application.DTOs;

using cqrsMediator.Infrastrusture.Presistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Queries.GetAllDevelopers
{
    public sealed class GetAllDevelopersQueryHandler(ApplicationDbContext _context,IMapper _mapper) :
        IRequestHandler<GetAllDevelopersQuery, List<DeveloperDTO>>
    {
        
        public async Task<List<DeveloperDTO>> Handle( GetAllDevelopersQuery request,CancellationToken cancellationToken)
        {
           

            var developers = await _context.Developers
             .ProjectTo<DeveloperDTO>(_mapper.ConfigurationProvider)
             .ToListAsync(cancellationToken);

            if (developers == null || developers.Count == 0)
            {
                throw new NotFoundException("Developer", "All");
            }

            return developers;

        }
    }
}
