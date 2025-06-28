using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using örnekproje.Models;
using tekkatmanproje.Data;

namespace örnekproje.Controllers
{
    public class ÜrünController : Controller
    {
        private readonly AppDbContext _product;

        public ÜrünController(AppDbContext product)
        {
            _product = product;
        }

        public IActionResult UrunDetay()
        {
            var products = _product.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.ProductID)
                .ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("UrunDetay");
            }

            var products = _product.Products
                .Include(p => p.Category)
                .Where(p => p.ProductName.Contains(searchTerm) ||
                           p.Description.Contains(searchTerm) ||
                           p.Category.CategoryName.Contains(searchTerm))
                .OrderByDescending(p => p.ProductID)
                .ToList();

            return View("UrunDetay", products);
        }
    }
}