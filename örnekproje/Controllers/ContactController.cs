﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace örnekproje.Controllers
{
    public class ContactController : Controller
    {
        // GET: /<controller>/
        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult İletisim()
        {
            return View();
        }
    }
}

