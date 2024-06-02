using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IIncidentDal: IEntityRepository<Incident>
    {

        List<Incident> GetListWithShiftWithGuard();    

        List<Incident> GetListWithShiftByGuard(int id); 

		
    }
}
