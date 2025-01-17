using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for session
using MVC_final.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MVC_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly Final_Project_dbContext db = new Final_Project_dbContext();
        public IActionResult Index()
        {
            // Retrieve username from session
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }
        public IActionResult Singup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Singup(User UserInfo)
        {
            if (db.Users.Any(x => x.Username == UserInfo.Username))
                {
                    ViewBag.Notification = "this account already existed";
                    return View();
                }
                else
                {
                    
                    db.Users.Add(UserInfo);
                    db.SaveChanges();
                    HttpContext.Session.SetString("Username", UserInfo.Username);
  
                }
            return RedirectToAction("Index","Home");
            
        } 
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User UserInfo)
        {
            var checkLogin = db.Users.Where(x => x.Username.Equals(UserInfo.Username) && x.Password.Equals(UserInfo.Password)).FirstOrDefault();
            if (checkLogin != null)
            {
                HttpContext.Session.SetString("Username", UserInfo.Username);
                return RedirectToAction("Index", "Home");
                /*switch (UserInfo.Property)
                {
                    case "User":
                        return RedirectToAction("Index", "Home");
                    case "Admin":
                        return RedirectToAction("Index", "Home");   
                    case "Seller":
                        return RedirectToAction("Index", "Home"); 
                }*/
            }
            else
            {
                ViewBag.Notification = "Wrong Username Or Password";
                
            }
            return View();
            
        }
    }
}
