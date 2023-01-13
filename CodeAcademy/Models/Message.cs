using System;
using System.ComponentModel.DataAnnotations;

namespace CodeAcademy.Models
{
    public class Message: Base
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(13)]
        public string Number { get; set; }
        [Required]
        public string EducationCategory { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
