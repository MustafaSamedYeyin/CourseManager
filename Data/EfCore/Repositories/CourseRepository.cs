using Core.Entities;
using Core.Interfaces.Data;
using Data.EfCore.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext _courseContext;
    

        public CourseRepository(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        public async Task<Course> AddAsync(Course course)
        {
            await _courseContext.AddAsync(course);
            return course;
        }

        public void Delete(Course course)
        {
            _courseContext.Remove(course);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
           return await _courseContext.Courses.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
           return await _courseContext.Courses.FindAsync(id);
        }

        public Course  Update(Course course)
        {
            _courseContext.Update(course);
            return course;
        }

        
    }
}
