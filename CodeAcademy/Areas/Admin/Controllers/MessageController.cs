using CodeAcademy.DAL;
using CodeAcademy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly AppDbContext db;
        public MessageController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Messages.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Message");
            return View(await db.Messages.FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Message");
            Message messageToDelete = await db.Messages.FindAsync(id);
            if (messageToDelete == null) return RedirectToAction("Index", "Message");
            db.Messages.Remove(messageToDelete);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Message");
        }
    }
}
