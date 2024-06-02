using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace Business.Abstract
{
    public interface IShiftService: IEntityRepository<Shift>
    {
    }
}
