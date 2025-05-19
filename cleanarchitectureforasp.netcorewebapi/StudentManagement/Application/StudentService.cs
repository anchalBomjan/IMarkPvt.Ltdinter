using StudentManagement.Domain;

namespace StudentManagement.Application
{

    //Application Layer -Service Class
    // Represents the bussinsess use cases and orchestrates calls to the Domain Layer
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        // Constructor Injection: Injejct the repository implementation from the infrastructure layer
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository= studentRepository;
        }

        
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students=await _studentRepository.GetAllStudentsAsync();

            //Convert Domain Model to DTOs (Application Layer)
            return students.Select(s => new StudentDTO 
            { 
             Id = s.Id,
             Name = s.Name,
             Email = s.Email,
             Age = s.Age,
            
            
            
            }).ToList();

          

        }

      
        // Use Case: Fetch a single student by ID (Application Layer)
        public async Task<StudentDTO?> GetStudentByIdAsync(int id)
        {
            // Domain Layer: Fetches data via repository (Infrastructure Layer)
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
                return null;
            // Convert Domain Model to DTO (Application Layer)
            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age
            };
        }


        public async Task AddStudentAsync(StudentDTO studentDto)
        {

            //Convert DTOs to Domain Model(Application Layer)
            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Age = studentDto.Age,

            };


            //Apply Bussiness rule (Domain Layer)
            student.ValidateAge();
            await _studentRepository.AddStudentAsync(student);
        }


        public async Task UpdateStudentAsync(int id, StudentDTO studentDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            
                throw new Exception("Student not found");

            

           // student.Id= studentDto.Id;  part of key cannot be modify so they are set as identitiy(1,1)
            student.Name = studentDto.Name;
            student.Email = studentDto.Email;
            student.Age= studentDto.Age;
            student.ValidateAge() ;
            await _studentRepository.UpdateStudentAsync(student);



        }


        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);


        }



    }
}
