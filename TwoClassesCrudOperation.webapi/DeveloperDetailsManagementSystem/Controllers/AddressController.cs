using DeveloperDetailsManagementSystem.Application;
using DeveloperDetailsManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace DeveloperDetailsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;
        public AddressController(AddressService addressService)
        {
            _addressService = addressService;




        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var adderess = await _addressService.GetAllAddressAsync();
            return Ok(adderess);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var adderess = await _addressService.GetAddressById(id);
            if (adderess == null) { return NotFound(); }
            return Ok(adderess);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]  CreateAdderessDTOs dtos)
        {
            await _addressService.AddAddressAsync(dtos);

            return Ok( new {  Message ="New Adderess is created"});
        }
        [HttpPut]
        public async Task<IActionResult>Put(int id, [FromBody] CreateAdderessDTOs dTOs)
        {
            await _addressService.UpdateAddressAsync(id,dTOs);
            return Ok(new { message = "Successfully you have edited  address" });

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok(new { message = "Successfully you have deleted" });
        }
    }
}
