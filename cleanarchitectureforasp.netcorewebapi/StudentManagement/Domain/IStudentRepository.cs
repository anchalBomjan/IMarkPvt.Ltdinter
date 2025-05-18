namespace StudentManagement.Domain
{ 

    //Domain Layer -Interface

    //Defines operations to interact  with students data(Implemented in the  infrastructure layers
    public interface IStudentRepository
    {
        Task<Student?>GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }
}
