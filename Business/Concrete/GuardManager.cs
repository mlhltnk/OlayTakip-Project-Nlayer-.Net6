using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GuardManager : IGuardService
    {
        IGuardDal _guardDal;

        public GuardManager(IGuardDal guardDal)
        {
            _guardDal = guardDal;
        }

        public void Add(Guard entity)
        {
            _guardDal.Add(entity);
        }

        public void Delete(Guard entity)
        {
            _guardDal.Delete(entity);
        }

        public Guard Get(Expression<Func<Guard, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Guard> GetAll(Expression<Func<Guard, bool>> filter = null)
        {
            return _guardDal.GetAll();
        }


        public Guard TGetById(int guardid)
        {
            return _guardDal.Get(c=>c.GuardId==guardid);
        }

        

   
        public void Update(Guard entity)
        {
            _guardDal.Update(entity);
        }
    }
}
