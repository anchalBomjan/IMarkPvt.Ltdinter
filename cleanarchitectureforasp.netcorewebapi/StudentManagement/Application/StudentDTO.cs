namespace StudentManagement.Application
{
    public class StudentDTO
    {


        // Represents data transferred between layers(e.g presentation layers to application layers

        public int Id { get; set; }
        public string? Name{ get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }


    }
}
