using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIncidentDal : EfEntityRepositoryBase<Incident, BaseDbContext>, IIncidentDal
    {
        
		public List<Incident> GetListWithShiftWithGuard()            
        {
            BaseDbContext context = new BaseDbContext();
            {
                return context.Incidents.Include(x => x.Shift).Include(x => x.Guard).ToList();
            }
        }


        public List<Incident> GetListWithShiftByGuard(int id)   
        {
            BaseDbContext context= new BaseDbContext();
            {
                return context.Incidents.Include(x => x.Shift).Where(x => x.GuardId == id).ToList();

            }
        }

    }
}
