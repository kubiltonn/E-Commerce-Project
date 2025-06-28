using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using örnekproje.Models;
using tekkatmanproje.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace örnekproje.Controllers
{
    public class CategoryController : Controller
    {

        private readonly AppDbContext _category;

        public CategoryController(AppDbContext category)
        {
            _category = category;
        }

        [HttpGet]
        public IActionResult Kategoriler()
        {
            var catList = _category.Categories.ToList();
            return View(catList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _category.Add(category);
            _category.SaveChanges();
            return RedirectToAction("Kategoriler");
        }
        public IActionResult Edit(int id)
        {
            var update = _category.Categories.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            _category.Update(category);
            _category.SaveChanges();

            return RedirectToAction("Kategoriler");

        }

        public IActionResult Delete(int id)
        {

            var delete = _category.Categories.Find(id);
            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            var deleteCategory = _category.Categories.Find(id);
            if (deleteCategory != null)
            {
                _category.Categories.Remove(deleteCategory);
                _category.SaveChanges();
            }

            return RedirectToAction("Kategoriler");

        }
    }
}

