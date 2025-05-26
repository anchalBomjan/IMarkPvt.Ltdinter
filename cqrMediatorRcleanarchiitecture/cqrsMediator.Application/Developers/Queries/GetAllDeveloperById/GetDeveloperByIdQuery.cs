using cqrsMediator.Application.DTOs;
using MediatR;


namespace cqrsMediator.Application.Developers.Queries.GetAllDeveloperById
{
    public record  GetDeveloperByIdQuery(int Id):IRequest<DeveloperDTO>;
    
}
