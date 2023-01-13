using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademy.Models
{
    public class Category: Base
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Group> Group { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
