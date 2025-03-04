namespace Student_Course_Management.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
