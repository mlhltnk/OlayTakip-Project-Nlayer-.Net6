using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace Business.Abstract
{
    public interface IIncidentService:IEntityRepository<Incident>
    {
        List<Incident> GetIncidentListWithShift();

        List<Incident> GetIncidentListById(int id);

        List<Incident> GetIncidentListwithShiftByGuard(int id);

        Incident GetById(int id);
    }
}
