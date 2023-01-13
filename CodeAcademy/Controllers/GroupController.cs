using CodeAcademy.DAL;
using CodeAcademy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeAcademy.Controllers
{
    public class GroupController : Controller
    {
        private readonly AppDbContext db;
        public GroupController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {

            GroupViewModel gvm = new GroupViewModel()
            {
                Groups = await db.Groups.Include(x => x.Category).Include(x => x.Teacher).ToListAsync(),
                Categories= await db.Categories.ToListAsync()
            };
            return View(gvm);
        }
        public async Task<IActionResult> GroupInfo()
        {

            GroupViewModel gvm = new GroupViewModel()
            {
                Groups = await db.Groups.Include(x => x.Students).Include(x => x.Teacher).ToListAsync(),
            };
            return View(gvm);
        }
    }
}
