using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public class User : IdentityUser<int>
    {
        public List<UserCourse> UserCourses { get; set; }
    }
}