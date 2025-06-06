﻿using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;

namespace StudentManagement.Infrastructure
{

    public class StudentRepositoroy:IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepositoroy(ApplicationDbContext  context)
        {

            _context = context;
            
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public  async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                 await  _context.SaveChangesAsync();
            }
            
        }

        public  async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
            
        }

        public  async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);

        }

        public  async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            
        }
    }
}
