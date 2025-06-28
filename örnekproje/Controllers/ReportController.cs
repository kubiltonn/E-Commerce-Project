using Microsoft.AspNetCore.Mvc;
using tekkatmanproje.Data;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using örnekproje.Models.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace örnekproje.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _report;
        public ReportController(AppDbContext context)
        {
            _report = context;
        }


        public IActionResult Index(string sortOrder)
        {
            ViewBag.ProductNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.StockSortParm = sortOrder == "Stock" ? "stock_desc" : "Stock";

            var result = from p in _report.Products
                         join c in _report.Categories on p.CategoryNo equals c.CategoryNo
                         select new ProCat
                         {
                             ProductName = p.ProductName,
                             Price = p.Price,
                             Stock = p.Stock,
                             CategoryID = c.CategoryNo,
                             CategoryName = c.CategoryName
                         };

            switch (sortOrder)
            {
                case "name_desc":
                    result = result.OrderByDescending(s => s.ProductName);
                    break;
                case "Price":
                    result = result.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    result = result.OrderByDescending(s => s.Price);
                    break;
                case "Stock":
                    result = result.OrderBy(s => s.Stock);
                    break;
                case "stock_desc":
                    result = result.OrderByDescending(s => s.Stock);
                    break;
                default:
                    result = result.OrderBy(s => s.ProductName);
                    break;
            }

            return View(result.ToList());
        }

        

    }
}

