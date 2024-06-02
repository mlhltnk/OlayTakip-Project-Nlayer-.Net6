using Entity.DTOs;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace MVC.Controllers
{
    

        [AllowAnonymous]
        public class RegisterController : Controller
        {
            private readonly UserManager<AppUser> _userManager;   //UserManager  sisteme kayıt olmak için construtor olarak eklenmeli(identityden geliyor)


            public RegisterController(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }



            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }



            [HttpPost]
            public async Task<IActionResult> Index(UserSignUpDtos p)
            {
                if (ModelState.IsValid)
                {
                    AppUser user = new AppUser()      
                    {
                        Email = p.Mail,               
                        UserName = p.UserName,         
                        NameSurname = p.nameSurname   
                        
                    
                    };


                    var result = await _userManager.CreateAsync(user, p.Password);
           




                if (result.Succeeded)
                    {
                    var guard = new Guard    
                    {
                        GuardName = user.NameSurname,
                        Mail = user.Email,
                        Status = true,
					};
                    BaseDbContext c = new BaseDbContext();
					// Guards tablosuna kaydedilmesi
					c.Guards.Add(guard);
					c.SaveChanges();
					return RedirectToAction("Index", "Login");  //başarılı ise login ekranına döner
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                   
                        }
                    }
                }
                return View(p);
            }

        }
    }
