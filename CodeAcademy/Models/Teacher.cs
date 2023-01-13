using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.Models
{
    public class Teacher: Base
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telephone { get; set; }
        public List<Group> Group { get; set; }
    }
}
