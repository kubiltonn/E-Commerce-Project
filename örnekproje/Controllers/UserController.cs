using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using örnekproje.Models;
using tekkatmanproje.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace örnekproje.Controllers
{
    public class UserController : Controller
    {

        private readonly AppDbContext _users;

        public UserController(AppDbContext users)
        {
            _users = users;
        }


        public IActionResult Kullanicilar()
        {

            var userList = _users.Users.ToList();
            return View(userList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(User user)
        {
            _users.Add(user);
            _users.SaveChanges();
            return RedirectToAction("Kullanicilar");
        }
        public IActionResult Edit(int id)
        {
            var update = _users.Users.Find(id);
            return View(update);
        }
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            _users.Update(user);
            _users.SaveChanges();

            return RedirectToAction("Kullanicilar");

        }
        public IActionResult Delete(int id)
        {

            var delete = _users.Users.Find(id);
            return View(delete);
        }
        [HttpPost]
        public IActionResult Delete(int id, User user)
        {
            _users.Remove(id);
            _users.SaveChanges();

            return RedirectToAction("Kullanicilar");

        }

    }
}

