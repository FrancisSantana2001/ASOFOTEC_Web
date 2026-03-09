using System.Diagnostics;
using ASOFOTEC_Web.Data;
using ASOFOTEC_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASOFOTEC_Web.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly AppdbContext _dbContext;

        public HomeController(AppdbContext context)
        {
            _dbContext = context;
        }
        public async Task <IActionResult> Index()
        {
            var user = _dbContext.ModelUsers.ToListAsync();
            return View(user);
        }

        [HttpPost]
        public async Task <IActionResult> Crear(ModelUser model)
        {
            if(!ModelState.IsValid)
                return View(model);
            _dbContext.Add(model);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
