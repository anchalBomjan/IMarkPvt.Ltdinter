using DeveloperDetailsManagementSystem.Application;
using DeveloperDetailsManagementSystem.Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperDetailsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly DeveloperService _developerService;
        public DeveloperController(DeveloperService developerService)
        {
            _developerService = developerService;
        }
        //GET:api/Developer
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _developerService.GetAllDeveloperAsync();
            return Ok(result);
        }

        //GET:/api/Developer/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var developer = await _developerService.GetDeveloperById(id);
            if (developer == null)
                return NotFound();

            return Ok(developer);
        }

        //POST: api/Developer
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DeveloperCreateDTOs dto)
        {
            await _developerService.AddDeveloperAsync(dto);
            return Ok(new { message = "Developer created successfully" });
        }


        //PUT: api/Developer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DeveloperCreateDTOs dto)
        {
            try
            {
                await _developerService.UpdateDeveloperAsync(id, dto);
                return Ok(new { message = "Developer updated successfully" });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        //DELETE: api/Developer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _developerService.DeleteDeveloperAsync(id);
            return Ok(new { message = "Developer deleted successfully" });
        }

    }
}
