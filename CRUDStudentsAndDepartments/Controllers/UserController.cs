using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using CRUDStudentsAndDepartments.Data;
using CRUDStudentsAndDepartments.Models;
using CRUDStudentsAndDepartments.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudentsAndDepartments.Controllers
{
    public class UserController : Controller
    {

        MvcDbContext db;

        CheckEmailService checkEmailService;

        public UserController(MvcDbContext _db,CheckEmailService checkEmailService)
        {
            db = _db;
            this.checkEmailService = checkEmailService;
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginModelView model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Include(s=>s.Roles).Where(u => u.Email == model.Email && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    Claim c1 = new Claim(ClaimTypes.Name, user.Name);
                    Claim c2 = new Claim(ClaimTypes.Email, user.Email);

                    ClaimsIdentity ci = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    ci.AddClaim(c1);
                    ci.AddClaim(c2);

                    foreach (var role in user.Roles)
                    {
                        Claim c3 = new Claim(ClaimTypes.Role, role.Name);
                        ci.AddClaim(c3);
                    }

                    ClaimsPrincipal cp = new ClaimsPrincipal(ci);

                    await HttpContext.SignInAsync(cp);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                    return View(model);
                }


            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                Role role = db.Roles.FirstOrDefault(r => r.Id == 3);
                user.Roles.Add(role);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View(user);
            }

        }

        public IActionResult CheckEmailExistance(string email)
        {
            var user = checkEmailService.CheckUserEmail(email);
            if (user != null)
                return Json(false);
            return Json(true);
        }

    }


}
