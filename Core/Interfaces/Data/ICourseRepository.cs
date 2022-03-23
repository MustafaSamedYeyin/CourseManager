using Core.Entities;

namespace Core.Interfaces.Data
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<Course> AddAsync(Course kurs);
        Course Update(Course kurs);
        void Delete(Course kurs);
    }
}