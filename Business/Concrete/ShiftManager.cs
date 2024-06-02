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
    public class ShiftManager : IShiftService
    {
        IShiftDal _shiftDal;

        public ShiftManager(IShiftDal shiftDal)
        {
            _shiftDal = shiftDal;
        }

        public void Add(Shift entity)
        {
            _shiftDal.Add(entity);
        }

        public void Delete(Shift entity)
        {
            _shiftDal.Delete(entity);
        }

        public Shift Get(Expression<Func<Shift, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Shift> GetAll(Expression<Func<Shift, bool>> filter = null)
        {
            return _shiftDal.GetAll();
        }


        public Shift GetById(int id)
        {
            return _shiftDal.Get(c => c.ShiftId == id);
        }
        
        public void Update(Shift entity)
        {
            _shiftDal.Update(entity);
        }
    }
}
