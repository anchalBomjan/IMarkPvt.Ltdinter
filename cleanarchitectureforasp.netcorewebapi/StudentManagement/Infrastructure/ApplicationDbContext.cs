using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;

namespace StudentManagement.Infrastructure
{
    public class ApplicationDbContext:DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed  data for the Students  table

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.deo@gmail.com",
                    Age = 18
                },
                new Student
                {
                    Id=2,
                    Name=" Jane Smith",
                    Email="jane.smth@gmail.com",
                    Age=19
                }
                
                );
        }

        public DbSet<Student> Students { get; set; }


    }
}
