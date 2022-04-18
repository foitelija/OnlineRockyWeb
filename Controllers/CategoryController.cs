﻿using Microsoft.AspNetCore.Mvc;
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
            _db.Category.Add(obj); // обращаемся  к нашей БД для заполнения полей
            _db.SaveChanges(); // сохраняем 
            return RedirectToAction("Index"); // возвращаем обновлённый результат
        }
    }
}
