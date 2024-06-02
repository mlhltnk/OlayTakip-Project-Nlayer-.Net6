using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            BaseDbContext c = new BaseDbContext();

            var username = User.Identity.Name;           

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            
   

            var guardid = c.Guards.Where(x => x.Mail == usermail).Select(y => y.GuardId).FirstOrDefault();  
          


            ViewBag.v1 = c.Incidents.Count().ToString();  
                                                           

            ViewBag.v2 = c.Incidents.Where(x => x.GuardId == guardid).Count();   
            


            ViewBag.v3 = c.Guards.Count().ToString();  

            return View();
        }
    }
}
