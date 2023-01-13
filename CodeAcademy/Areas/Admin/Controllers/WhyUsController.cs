using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeAcademy.DAL;
using CodeAcademy.Models;
using Microsoft.AspNetCore.Hosting;
using CodeAcademy.Utils;
using System.IO;

namespace CodeAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WhyUsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public WhyUsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.whyUs.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.whyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View(whyUs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Subtitle,Image,Id,ImageFile")] WhyUs whyUs)
        {
            if (ModelState.IsValid)
            {
                if (!whyUs.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                if (!whyUs.ImageFile.IsValidSize(5000))
                {
                    ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
                    return View();
                }
                whyUs.Image = await whyUs.ImageFile.Upload(_env.WebRootPath, @"assets\img\Upload\WhyUs");
                _context.Add(whyUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whyUs);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.whyUs.FindAsync(id);
            if (whyUs == null)
            {
                return NotFound();
            }
            return View(whyUs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Subtitle,Image,Id,ImageFile")] WhyUs whyUs)
        {
            if (ModelState.IsValid)
            {
                if (!whyUs.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "File must be an image.");
                    return View();
                }
                if (!whyUs.ImageFile.IsValidSize(5000))
                {
                    ModelState.AddModelError("ImageFile", "Max file size is 5000 kbs.");
                    return View();
                }
                string filePath = Path.Combine(_env.WebRootPath, @"assets\img\Upload\WhyUs", whyUs.Image);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                whyUs.Image = await whyUs.ImageFile.Upload(_env.WebRootPath, @"assets\img\Upload\WhyUs");
                _context.Update(whyUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whyUs);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whyUs = await _context.whyUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whyUs == null)
            {
                return NotFound();
            }

            return View(whyUs);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whyUs = await _context.whyUs.FindAsync(id);
            string filePath = Path.Combine(_env.WebRootPath, @"assets\img\Upload\WhyUs", whyUs.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.whyUs.Remove(whyUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhyUsExists(int id)
        {
            return _context.whyUs.Any(e => e.Id == id);
        }
    }
}
