using Microsoft.EntityFrameworkCore;
using Student_Course_Management.Data;
using Student_Course_Management.Models;


namespace Student_Course_Management.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.Include(s => s.Courses).ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteStudentAsync(int id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student != null) _context.Students.Remove(student);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
