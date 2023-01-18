using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Site.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site.Controllers
{
    [AllowAnonymous] //Kurallardan muaf olmalı.
    public class ListeleController : Controller
    {
        private readonly Context _db;

        public ListeleController(Context db)
        {
            _db = db; /* dependency injection : bagımlılık çözücü*/
        }


        public async Task<IActionResult> Index()  //
        {
            var listele = await _db.Movies.ToListAsync();  //await:uygulamayı bekletip baska bir göreve geciyor.İşlemi hızlandırıyor.performansı artıyor
            return View(listele);
        }
    }
}
