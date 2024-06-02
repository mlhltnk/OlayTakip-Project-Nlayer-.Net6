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
    public class EfGuardDal: EfEntityRepositoryBase<Guard,BaseDbContext>,IGuardDal
    {
    }
}
