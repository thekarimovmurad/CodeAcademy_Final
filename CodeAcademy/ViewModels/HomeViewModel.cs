using CodeAcademy.Models;
using System.Collections.Generic;

namespace CodeAcademy.ViewModels
{
    public class HomeViewModel
    {
        public List<Header> Headers { get; set; }
        public List<WhyUs> whyUs { get; set; }
        public List<Category> Categorys { get; set; }
        public List<Message> Messages { get; set; }

    }
}
