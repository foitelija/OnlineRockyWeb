using Microsoft.AspNetCore.Mvc;
using OnlineRockyWeb.Data;
using OnlineRockyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRockyWeb.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        //GET - CREATE
        public IActionResult Create()
        {

            return View();
        }

        //Post - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken] // токен безопасности
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj); // обращаемся  к нашей БД для заполнения полей
            _db.SaveChanges(); // сохраняем 
            return RedirectToAction("Index"); // возвращаем обновлённый результат
        }
    }
}
