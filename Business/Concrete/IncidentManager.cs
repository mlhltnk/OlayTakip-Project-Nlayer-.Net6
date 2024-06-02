using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class IncidentManager : IIncidentService
    {
        IIncidentDal _incidentDal;

        public IncidentManager(IIncidentDal incidentDal)
        {
            _incidentDal = incidentDal;
        }


        public List<Incident> GetIncidentListWithShift()    
        {
            return _incidentDal.GetListWithShiftWithGuard();
        }


		public List<Incident> GetIncidentListById(int id)       
		{
			return _incidentDal.GetAll(x => x.IncidentId == id);
		}


		public List<Incident> GetIncidentListwithShiftByGuard(int id)      
                                                                            
        {
            return _incidentDal.GetListWithShiftByGuard(id);
        }


        public Incident GetById(int id)
        {
        
            return _incidentDal.Get(c => c.IncidentId == id);
        }

        public List<Incident> GetAll(Expression<Func<Incident, bool>> filter = null)
        {
            return _incidentDal.GetAll();
        }

    
        public void Add(Incident entity)
        {
            _incidentDal.Add(entity);
        }

        public void Update(Incident entity)
        {
            _incidentDal.Update(entity);
        }

        public void Delete(Incident entity)
        {
            _incidentDal.Delete(entity);
        }

        public Incident Get(Expression<Func<Incident, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
