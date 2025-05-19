using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application;
using System.Runtime.CompilerServices;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentservice;
        public StudentController(StudentService studentservice)
        {
            _studentservice = studentservice;
        }
        // Get: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetAllStudents()
        {

            var students = await _studentservice.GetAllStudentsAsync();
            return Ok(students);
        }

        //GET :api/students /{id}
        [HttpGet("{id}")]

        public async Task<ActionResult<StudentDTO>>GetStudent(int id)
        {
            var student = await _studentservice.GetStudentByIdAsync(id);
            if(student== null)
            {
                return NotFound();


            }
            return Ok(student);
        }
        //POST: api/students
        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] StudentDTO studentDto)
        {
            await _studentservice.AddStudentAsync(studentDto);
            return CreatedAtAction(nameof(AddStudent), studentDto); 
        }

        // PUT: api/students/{id}
        [HttpPut("{id}")]

        public async Task<ActionResult>UpdateStudent(int id, [FromBody] StudentDTO studentDto)
        {
            await _studentservice.UpdateStudentAsync(id, studentDto);
            return NoContent();
        }


        //DELETE: api/students/{id}
        [HttpDelete("{id}")]

        public async Task <ActionResult>DeleteStudent(int id)
        {
            await _studentservice.DeleteStudentAsync(id);
            return NoContent();
        }


    }
}
