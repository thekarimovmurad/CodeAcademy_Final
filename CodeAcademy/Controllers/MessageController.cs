using CodeAcademy.DAL;
using CodeAcademy.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodeAcademy.Controllers
{
    public class MessageController : Controller
    {
        private readonly AppDbContext db;
        public MessageController(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Add(string Name, string Surname, string LocalCode, string Number, string EducationCategory)
        {
            if (Name != null && Surname != null && Number != null)
            {
                Message message = new Message()
                {
                    Name = Name,
                    Surname = Surname,
                    Number = LocalCode + Number,
                    EducationCategory = EducationCategory,
                    MessageDate = DateTime.Now,
                };
                db.Messages.Add(message);
                db.SaveChanges();
                TempData["messageAdded"] = "Your message was added successsfully";
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
