namespace Core.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserCourse> UserCourses { get; set; }
    }
}