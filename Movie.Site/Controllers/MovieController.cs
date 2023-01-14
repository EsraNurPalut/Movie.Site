using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Site.Data;
using Movie.Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site.Controllers
{
    public class MovieController : Controller
    {
        private readonly Context _db;

        public MovieController(Context db)
        {
            _db = db;
        }


        public async Task<IActionResult> Index()  //
        {
            var listele = await _db.Movies.ToListAsync();  //await:uygulamayı bekletip baska bir göreve geciyor.İşlemi hızlandırıyor.performansı artıyor
            return View(listele);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movies movie)
        {
            _db.Add(movie);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _db.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _db.Movies.FirstOrDefaultAsync(m => m.MovieId == id);
            _db.Movies.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yenile = await _db.Movies.FindAsync(id);
            if (yenile == null)
            {
                return NotFound();
            }

            return View(yenile);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Movies movie)
        {
            _db.Update(movie);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
