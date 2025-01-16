using Microsoft.AspNetCore.Mvc;
using Task3.Data;
using Task3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task3.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext db;
        public AccountController(AppDbContext _db)
        {
            db = _db;
        }
    
    
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login() { return View(); }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var data = db.Users.Where(x => x.Password == user.Password && x.Email == user.Email).FirstOrDefault();
            if (data!=null)
            {
                return RedirectToAction("LoginHome");
            }
            return View();
        }
        public IActionResult LoginHome() {  return View(); }
    }
}



