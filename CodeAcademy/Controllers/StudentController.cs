using CodeAcademy.DAL;
using CodeAcademy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext db;
        public StudentController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Group");
            ViewBag.Group = db.Groups.Include(x => x.Category).FirstOrDefault(x => x.Id == id);
            ViewBag.Teacher = db.Groups.Include(x => x.Teacher).FirstOrDefault(x => x.Id == id);
            ViewBag.StudentCount=db.Students.Where(x=>x.GroupId==id).Count();
            return View(await db.Students.Include(x => x.Group).Where(x => x.GroupId == id).ToListAsync());
        }
        public async Task<IActionResult> Info(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Student");
            return View(await db.Students.Include(x => x.Group).Include(x => x.Group.Teacher).Include(x => x.Group.Category).FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}