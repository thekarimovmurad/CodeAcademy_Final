using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademy.Models
{
    public class Student:Base
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Image { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
