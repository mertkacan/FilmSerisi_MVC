using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_060223.Data;
using MVC_060223.Models;
using System.Diagnostics;

namespace MVC_060223.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;


        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db)
        {
            _logger = logger;
            _db=db;
        }

        public IActionResult Index(int? turId, string? sira)
        {
            IQueryable<Film> filmler = _db.Filmler.Include(x => x.Turler);

            if (turId != null)
                filmler = filmler.Where(x => x.Turler.Any(y => y.Id== turId));

            ViewBag.Turler = _db.Turler.Select(x => new SelectListItem()
            {
                Text = x.Ad,
                Value = x.Id.ToString()
            }).ToList();

            if (sira == "ad")
                filmler =  filmler.OrderBy(x => x.Ad);

            else if (sira == "yil")
                filmler =  filmler.OrderBy(x => x.Yil);

            else if (sira == "puan")
                filmler =  filmler.OrderBy(x => x.Puan);

            var vm = new HomeViewModel()
            {
                Filmler = filmler.ToList(),
                TurId = turId
            };



            return View(vm);
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