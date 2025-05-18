using StudentManagement.Domain;

namespace StudentManagement.Application
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository= studentRepository;
        }

        
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students=await _studentRepository.GetAllStudentsAsync();
            return students.Select(s => new StudentDTO 
            { 
             Id = s.Id,
             Name = s.Name,
             Email = s.Email,
             Age = s.Age,
            
            
            
            }).ToList();

          

        }



        public async Task AddStudentAsync(StudentDTO studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Email = studentDto.Email,
                Age = studentDto.Age,

            };

            student.ValidateAge();
            await _studentRepository.AddStudentAsync(student);
        }


        public async Task UpdateStudentAsync(int id, StudentDTO studenmtDto)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            
                throw new Exception("Student not found");

            


            student.Name = studenmtDto.Name;
            student.Email = studenmtDto.Email;
            student.Age= studenmtDto.Age;
            student.ValidateAge() ;
            await _studentRepository.UpdateStudentAsync(student);



        }


        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);


        }



    }
}
