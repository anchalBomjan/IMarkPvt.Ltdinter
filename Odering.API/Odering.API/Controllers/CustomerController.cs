using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands.Customers.Create;
using Ordering.Application.Commands.Customers.Delete;
using Ordering.Application.Commands.Customers.Update;
using Ordering.Application.DTOs;
using Ordering.Application.Queries.Customers;
using Ordering.Core.Entities;

namespace Ordering.API.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Customer>> Get()
        {

            return await _mediator.Send(new GetAllCustomerQuery());
        }

        [HttpPut("{id}")]
        public async Task<Customer> Get(Int64 id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id));
        }

        [HttpGet("email")]
        public async Task<Customer> GetByGmail(string email)
        {
            return await _mediator.Send(new GetCustomerByEmailQuery(email));
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //errors occurs if IActionResult used in below function
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("Edit/{id}")]

        public async Task<ActionResult> Edit(int id, [FromBody] EditCustomerCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles ="Admin,Management")]
        [HttpDelete("Delete/{id}")]

        public async Task<ActionResult>DeleteCustomer(int id)
        {
            try
            {
               // var result = await _mediator.Send(new DeleteCustomerCommand(id));
                 string result = string.Empty;
                 result = await _mediator.Send(new DeleteCustomerCommand(id));
                 return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
