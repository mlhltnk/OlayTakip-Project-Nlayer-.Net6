using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfShiftDal: EfEntityRepositoryBase<Shift,BaseDbContext>, IShiftDal
    {
    }
}

//