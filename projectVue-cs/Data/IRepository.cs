using System.Threading.Tasks;
using projectVue.Models;

namespace projectVue.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync<T>(T entity);

        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);
        Task<Student[]> GetStudentsAsyncByTeacherId(int TeacherId, bool includeTeacher);
        Task<Student> GetStudentAsyncById(int studentId, bool includeTeacher);

        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);
        Task<Teacher> GetTeacherAsyncById(int teacherId, bool includeStudent);
    }
}
