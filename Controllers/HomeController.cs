using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GoodAppleProj.Models;

namespace GoodAppleProj.Controllers
{
    public class HomeController : Controller
    {
        private GoodAppleContext dbContext;
        public HomeController(GoodAppleContext context){
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("NewTeacher")]
        public IActionResult NewTeacher(WrapperModel modelData){
            User AddUser = modelData.NewUser;
            Teacher AddTeacher = modelData.NewTeacher;
            if(ModelState.IsValid){
                if(dbContext.users.Any(u => u.Email == AddUser.Email)){
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    AddUser.Password = Hasher.HashPassword(AddUser, AddUser.Password);
                    AddTeacher.User = AddUser;
                    dbContext.teachers.Add(AddTeacher);
                    dbContext.users.Add(AddUser);
                    dbContext.SaveChanges();
                    if(HttpContext.Session.GetInt32("UserId") == null){
                        HttpContext.Session.SetInt32("UserId", AddUser.UserId);
                    }
                    return RedirectToAction("Dashboard");
                }
            } else {
                return View("Index");
            }
        }

        [HttpPost("NewUser")]
        public IActionResult NewUser(WrapperModel modelData){
            User AddUser = modelData.NewUser;
            if(ModelState.IsValid){
                if(dbContext.users.Any(u => u.Email == AddUser.Email)){
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    AddUser.Password = Hasher.HashPassword(AddUser, AddUser.Password);
                    dbContext.users.Add(AddUser);
                    dbContext.SaveChanges();
                    if(HttpContext.Session.GetInt32("UserId") == null){
                        HttpContext.Session.SetInt32("UserId", AddUser.UserId);
                    }
                    return RedirectToAction("Dashboard");
                }
            } else {
                return View("Index");
            }
        }

        public IActionResult Dashboard(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
