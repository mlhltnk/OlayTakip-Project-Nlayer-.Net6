using Business.Concrete;
using Entity;
using Entity.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{

    public class GuardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public GuardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult GuardNavbarPartial()
        {
            return PartialView();
        }


        public PartialViewResult GuardFooterPartial()
        {
            return PartialView();
        }



        [HttpGet]
        public async Task<IActionResult> GuardEditProfile()
        {


            var values = await _userManager.FindByNameAsync(User.Identity.Name);    

            UserUpdateDtos model = new UserUpdateDtos();    

            model.mail = values.Email;
            model.namesurname = values.NameSurname;
            model.username = values.UserName;

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> GuardEditProfile(UserUpdateDtos model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            values.Email = model.mail;
            values.NameSurname = model.namesurname;

            if (!string.IsNullOrWhiteSpace(model.password))   
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);     
            }
             

            var result = await _userManager.UpdateAsync(values);   

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
