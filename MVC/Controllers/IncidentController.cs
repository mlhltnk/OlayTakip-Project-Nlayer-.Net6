using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Business.Abstract;
using Humanizer;

namespace MVC.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IIncidentService _service;

        public IncidentController(IIncidentService service)
        {
            _service = service;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult IncidentListByGuard()   //olay sayfasında olayları nöbetlerle beraber getir ancak nöbetçiye göre getir
        {
            BaseDbContext c = new BaseDbContext();

            var username = User.Identity.Name;           

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
          

            var guardID = c.Guards.Where(x => x.Mail == usermail).Select(y => y.GuardId).FirstOrDefault();  
          

            var values = _service.GetIncidentListwithShiftByGuard(guardID);
		

			return View(values);
        }





        [HttpGet]
        public IActionResult IncidentAdd()
        {
      
            ShiftManager cm = new ShiftManager(new EfShiftDal());

            List<SelectListItem> shiftvalues = (from x in cm.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.ShiftType,  //dropdown içinde kullanıcının gördüğü kısım
                                                       Value = x.ShiftId.ToString()  //kullanıcıya görünmeyen kısım
                                                   }).ToList();
            ViewBag.cv = shiftvalues;  
           
            return View();
        }




        [HttpPost]
        public IActionResult IncidentAdd(Incident p)
        {
      
            BaseDbContext c = new BaseDbContext();
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
         

            var guardID = c.Guards.Where(x => x.Mail == usermail).Select(y => y.GuardId).FirstOrDefault();
      

            p.GuardId = guardID;  
     
            
            p.IncidentDatetime = DateTime.Parse(DateTime.Now.ToShortDateString());
              
            _service.Add(p);
            return RedirectToAction("IncidentListByGuard", "Incident"); 
        }



        public IActionResult IncidentReadAll(int id)   
        {
            var values = _service.GetIncidentListById(id);
            return View(values);
		}


        public IActionResult IncidentDelete(int id)
        {
            var values = _service.GetById(id);
            _service.Delete(values);
            return RedirectToAction("IncidentListByGuard");
        }


        [HttpGet]
        public IActionResult IncidentEdit(int id)
        {
            var values = _service.GetById(id);

            ShiftManager cm = new ShiftManager(new EfShiftDal());

            List<SelectListItem> shiftvalues = (from x in cm.GetAll()
                                                select new SelectListItem
                                                {
                                                    Text = x.ShiftType,  //dropdown içinde kullanıcının gördüğü kısım
                                                    Value = x.ShiftId.ToString()  //kullanıcıya görünmeyen kısım
                                                }).ToList();
            ViewBag.cv = shiftvalues; 

            return View(values);
        }


        [HttpPost]
        public IActionResult IncidentEdit(Incident p)
        {
          
            BaseDbContext c = new BaseDbContext();
            var username = User.Identity.Name;

            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();


            var guardID = c.Guards.Where(x => x.Mail == usermail).Select(y => y.GuardId).FirstOrDefault();
            

            p.GuardId = guardID;    

            p.IncidentDatetime = DateTime.Parse(DateTime.Now.ToShortDateString());

           
            _service.Update(p);
            

            return RedirectToAction("IncidentListByGuard", "Incident");
        }

        public IActionResult IncidentList(DateTime? filterDate)
        {
            IncidentManager im = new IncidentManager(new EfIncidentDal());

            DateTime selectedDate = filterDate ?? DateTime.Today;

            // Veritabanından tarihe göre olayları getir
            var incidents = im
                .GetIncidentListWithShift()
                .Where(i => i.IncidentDatetime.Date == selectedDate.Date)
                .ToList();

            ViewBag.FilterDate = filterDate?.ToString("yyyy-MM-dd") ?? DateTime.Today.ToString("yyyy-MM-dd");


            return View("IncidentList", incidents);
        }

    }
}
