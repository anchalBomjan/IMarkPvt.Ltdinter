// Application/Developers/Queries/GetAllDevelopers/GetAllDevelopersQueryHandler.cs
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;

        //public GetAllDevelopersQueryHandler(ApplicationDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        public async Task<List<DeveloperDTO>> Handle(
            GetAllDevelopersQuery request,
            CancellationToken cancellationToken)
        {
            return await _context.Developers
                .ProjectTo<DeveloperDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
