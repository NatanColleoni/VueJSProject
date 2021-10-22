using Microsoft.EntityFrameworkCore;
using projectVue.Models;
using System.Linq;
using System.Threading.Tasks;

namespace projectVue.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get;  }
        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<bool> SaveChangesAsync<T>(T entity)
        {
            return (await _context.SaveChangesAsync() > 0);
        }


        //Student
        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if(includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student[]> GetStudentsAsyncByTeacherId(int teacherId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(s => s.TeacherId == teacherId);

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(t => t.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(s => s.Id == studentId);

            return await query.FirstOrDefaultAsync();
        }


        //Teacher
        public async Task<Teacher[]> GetAllTeachersAsync(bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Students);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(t => t.Students);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id).Where(t => t.Id == teacherId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
