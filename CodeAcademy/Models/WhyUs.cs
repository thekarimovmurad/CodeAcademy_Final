using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeAcademy.Models
{
    public class WhyUs: Base
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
