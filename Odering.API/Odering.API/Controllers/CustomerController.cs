using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Queries.Customers;
using Ordering.Core.Entities;

namespace Ordering.API.Controllers
{

    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator=mediator;
        }
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Customer>> Get()
        {

            return await _mediator.Send(new GetAllCustomerQuery());
        }

    }
}
