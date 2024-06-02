using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MVC.ViewComponents.Incident
{

    public class IncidentListDashboard:ViewComponent
    {
        IncidentManager im = new IncidentManager(new EfIncidentDal());

        public IViewComponentResult Invoke()
        {
            //olayları nöbetle beraber getir dashboardda listele

            var values = im.GetIncidentListWithShift();

            return View(values);
        }
    }

}