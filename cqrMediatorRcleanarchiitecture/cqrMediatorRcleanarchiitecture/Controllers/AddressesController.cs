using cqrsMediator.Application.Addresses.Commands.CreateAddress;
using cqrsMediator.Application.Addresses.Commands.DeleteAddress;
using cqrsMediator.Application.Addresses.Commands.UpdateAddress;
using cqrsMediator.Application.Addresses.Queries.GetAddressById;
using cqrsMediator.Application.Addresses.Queries.GetAllAddress;
using cqrsMediator.Application.Developers.Commands.UpdateDeveloper;
using cqrsMediator.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cqrsMediatorWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> GetAll()
        {
            var addresses = await _mediator.Send(new GetAllAddressesQuery());
            return Ok(addresses);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetById(int id)
        {
            var address = await _mediator.Send(new GetAddressByIdQuery(id));
            return address != null ? Ok(address) : NotFound();
        }

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAddressCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAddressCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _mediator.Send(command);
            return NoContent();
        }



        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAddressCommand(id));
            return NoContent();
        }

    }
}
