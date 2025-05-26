using cqrsMediator.Application.Developers.Commands.CreateDeveloper;
using cqrsMediator.Application.Developers.Commands.DeleteDeveloper;
using cqrsMediator.Application.Developers.Commands.UpdateDeveloper;
using cqrsMediator.Application.Developers.Queries.GetAllDeveloperById;
using cqrsMediator.Application.Developers.Queries.GetAllDevelopers;
using cqrsMediator.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrsMediatorWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Developers
        [HttpGet]
        public async Task<ActionResult<List<DeveloperDTO>>> GetAll()
        {
            var developers = await _mediator.Send(new GetAllDevelopersQuery());
            return Ok(developers);
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeveloperDTO>> GetById(int id)
        {
            var developer = await _mediator.Send(new GetDeveloperByIdQuery(id));
            return developer != null ? Ok(developer) : NotFound();
        }

        // POST: api/Developers
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDeveloperCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // PUT: api/Developers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDeveloperCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteDeveloperCommand(id));
            return NoContent();
        }

    }
}
