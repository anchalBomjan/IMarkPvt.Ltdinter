using cqrsMediator.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Queries.GetAllDevelopers
{
   // public record GetAllDevelopersQuery : IRequest<List<DeveloperDTO>>;

    public record GetAllDevelopersQuery : IRequest<List<DeveloperDTO>>;




}
