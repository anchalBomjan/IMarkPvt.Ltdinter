﻿using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Webapi.Controllers
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
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var adderess = await _addressService.GetAllAddressAsync();
        //    return Ok(adderess);
        //}


        ////GET:api/Adderess/Id
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var adderess = await _addressService.GetAddressById(id);
        //    if (adderess == null) { return NotFound(); }
        //    return Ok(adderess);

        //}

        ////POST: api/Adderess

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody]  CreateAdderessDTOs dtos)
        //{
        //    await _addressService.AddAddressAsync(dtos);

        //    return Ok( new {  Message ="New Adderess is created"});
        //}
        ////PUT: api/Adderess/{id}
        //[HttpPut]
        //public async Task<IActionResult>Put(int id, [FromBody] CreateAdderessDTOs dTOs)
        //{
        //    await _addressService.UpdateAddressAsync(id,dTOs);
        //    return Ok(new { message = "Successfully you have edited  address" });

        //}

        ////DELETE:api/Adderess/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _addressService.DeleteAddressAsync(id);
        //    return Ok(new { message = "Successfully you have deleted" });
        //}







        /// <summary>
        ///   for API Documentation Testing best use of ActionResult
        /// </summary>
        /// <returns></returns>

        //GET:api/Adderess
        [HttpGet]
        public async Task<ActionResult<AddressDTO>> GetAll()
        {

            var adderesses = await _addressService.GetAllAddressAsync();
            return Ok(adderesses);
        }
        //GET:api/Adderess







        //GET:api/Adderess/{id}
        [HttpPost("{id}")]
        public async Task<ActionResult<CreateAddressDTO>> GetById(int id)
        {
            var adderess = await _addressService.GetAddressById(id);
            if (adderess == null) { return NotFound(); }
            return Ok(adderess);
        }
        //Post:api/Adderess


        [HttpPost]
        public async Task<ActionResult> Create(CreateAddressDTO createAdderessDTO)
        {
            await _addressService.AddAddressAsync(createAdderessDTO);
            return Ok(createAdderessDTO);


        }
        //PUT: api/Adderess/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateAddressDTO addressDTO)
        {
            await _addressService.UpdateAddressAsync(id, addressDTO);
            return Ok(addressDTO);
        }
        //DELETE:api/Adderess/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _addressService.DeleteAddressAsync(id);
            return Ok();
        }




    }
}
