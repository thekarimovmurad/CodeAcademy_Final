using System.Collections.Generic;

namespace CodeAcademy.Models
{
    public class Group: Base
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

    }
}