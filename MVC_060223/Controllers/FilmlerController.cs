using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_060223.Data;
using MVC_060223.Models;

namespace MVC_060223.Controllers
{
    public class FilmlerController : Controller
    {
        private readonly UygulamaDbContext _db;
        public FilmlerController(UygulamaDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Filmler.Include(x => x.Turler).ToList());
        }

        public IActionResult Yeni()
        {
            ViewBag.Turler = _db.Turler.ToList();
            var vm = new YeniFilmViewModel();
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(YeniFilmViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Film film = new Film()
                {
                    Ad = vm.Ad,
                    Puan = vm.Puan!.Value,
                    Yil = vm.Yil,
                    Turler = _db.Turler.Where(x => vm.Turler.Contains(x.Id)).ToList()
                };

                _db.Filmler.Add(film);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Turler = _db.Turler.ToList();

            return View(vm);
        }

        public IActionResult Duzenle(int id)
        {
            var film = _db.Filmler.Include(x => x.Turler).FirstOrDefault(x => x.Id == id);
            ViewBag.Turler = _db.Turler.ToList();

            if (film == null)
                return NotFound();

            var vm = new FilmDuzenleViewModel()
            {
                Id = film.Id,
                Yil= film.Yil,
                Ad= film.Ad,
                Puan= film.Puan,
                Turler = film.Turler.Select(x => x.Id).ToArray()
            };


            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Duzenle(FilmDuzenleViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var film = _db.Filmler.Include(x => x.Turler).FirstOrDefault(x => x.Id == vm.Id);

                if (film == null)
                    return NotFound();

                film!.Ad = vm.Ad;
                film.Puan = Convert.ToDecimal(vm.Puan);
                film.Yil = vm.Yil;
                film.Turler.Clear();
                film.Turler = _db.Turler.Where(x => vm.Turler.Contains(x.Id)).ToList();

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Turler = _db.Turler.ToList();

            return View(vm);
        }

        public IActionResult Sil(int id)
        {
            Film? film = _db.Filmler.Find(id);

            if (film == null)
                return NotFound();

            return View(film);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SilOnay(int id)
        {
            Film? film = _db.Filmler.Find(id);

            if (film == null)
                return NotFound();

            _db.Remove(film);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
