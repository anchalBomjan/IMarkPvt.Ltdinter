namespace StudentManagement.Domain
{

    // Domain layer - Entity
    //Presents the core business logic and rules for student
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }


        // Business Rule: Ensure that the age is between 5 and 60


        public void ValidateAge()
        {
            if(Age <5 || Age > 60)
            {
                throw new Exception("Age must be between 5 and 60");
            }
        }
    }
}
