using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cqrsMediator.Application.Developers.Commands.DeleteDeveloper
{
    public record DeleteDeveloperCommand(int id) : IRequest;


}
