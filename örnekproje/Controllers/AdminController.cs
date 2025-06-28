using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using örnekproje.Models;
using tekkatmanproje.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace örnekproje.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _product;

        public AdminController (AppDbContext product)
        {
            _product = product;
        }


        [HttpGet]
        public IActionResult AdminPage()
        {
            var productList = _product.Products.Include(p => p.Category).ToList();
            return View(productList);

            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_product.Categories, "CategoryNo", "CategoryName");
            return View();

        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _product.Add(product);
            _product.SaveChanges();
            return RedirectToAction("AdminPage");
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_product.Categories, "CategoryNo", "CategoryName");
            var update = _product.Products.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            _product.Update(product);
            _product.SaveChanges();

            return RedirectToAction("AdminPage");

        }
        public IActionResult Delete(int id)
        {
            ViewBag.Categories = new SelectList(_product.Categories, "CategoryNo", "CategoryName");

            var delete = _product.Products.Find(id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
           _product.Remove(id);
            _product.SaveChanges();

            return RedirectToAction("AdminPage");

        }


    }
}

