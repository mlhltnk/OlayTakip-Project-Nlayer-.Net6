using Entity.DTOs;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
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
        public async Task<IActionResult> Index(UserSingInDtos p)       //login işlemi
        {
            if (ModelState.IsValid)                           
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return View();
            }


        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()        //yetkisiz kullanıcının yönleneceği sayfa
        {
            return View();
        }
    }
}
