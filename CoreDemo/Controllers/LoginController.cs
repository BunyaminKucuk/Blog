using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreDemo.Models;
using Microsoft.AspNetCore.Identity;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel appUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "DashBoard");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");

            }

            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //    Context context = new Context();
        //    var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
        //                                                          x.WriterPassword == writer.WriterPassword);
        //    if (dataValue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, writer.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(claimsPrincipal);
        //        return RedirectToAction("Index", "DashBoard");
        //    }
        //    else
        //    {
        //        return View();

        //    }

    }
}
