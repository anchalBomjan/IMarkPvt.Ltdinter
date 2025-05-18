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

        
    }
}
