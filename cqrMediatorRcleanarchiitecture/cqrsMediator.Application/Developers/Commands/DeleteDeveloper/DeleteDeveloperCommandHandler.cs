using cqrsMediator.Infrastrusture.Presistance;
using MediatR;
namespace cqrsMediator.Application.Developers.Commands.DeleteDeveloper
{

    public sealed class DeleteDeveloperCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteDeveloperCommand>
    {
        public async Task Handle(DeleteDeveloperCommand request, CancellationToken ct)
        {
            var developer = await context.Developers.FindAsync(request);
            if (developer != null)
            {
                context.Remove(developer);
                await context.SaveChangesAsync();
            }
        }
    }
}
