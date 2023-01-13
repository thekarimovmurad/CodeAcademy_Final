namespace CodeAcademy.Models
{
    public class StudentMark: Base
    {
        public int AvarageMark { get; set; }
        public int MarkCount { get; set; }
        public Student Student { get; set; }
    }
}
