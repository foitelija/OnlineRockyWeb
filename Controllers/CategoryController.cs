using Microsoft.AspNetCore.Mvc;
using OnlineRockyWeb.Data;
using OnlineRockyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRockyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
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
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
            _db.Category.Add(obj); // обращаемся  к нашей БД для заполнения полей
            _db.SaveChanges(); // сохраняем 
            return RedirectToAction("Index"); // возвращаем обновлённый результат
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken] // токен безопасности
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj); // обращаемся  к нашей БД для заполнения полей
                _db.SaveChanges(); // сохраняем 
                return RedirectToAction("Index"); // возвращаем обновлённый результат
            }
            return View(obj);
        }


        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken] // токен безопасности
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj==null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj); // обращаемся  к нашей БД для заполнения полей
            _db.SaveChanges(); // сохраняем 
            return RedirectToAction("Index"); // возвращаем обновлённый результат
        }
    }
}
