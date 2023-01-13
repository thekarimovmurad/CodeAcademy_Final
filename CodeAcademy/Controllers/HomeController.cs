using CodeAcademy.DAL;
using CodeAcademy.Models;
using CodeAcademy.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CodeAcademy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext db;
        public HomeController(AppDbContext _db)
        {
            db = _db;
        }
        public async Task<IActionResult> Index()
        {
            HomeViewModel hvm = new HomeViewModel()
            {
                Headers = await db.Headers.ToListAsync(),
                whyUs = await db.whyUs.ToListAsync(),
                Categorys = await db.Categories.ToListAsync(),  

            };
            return View(hvm);
        }
    }
}
