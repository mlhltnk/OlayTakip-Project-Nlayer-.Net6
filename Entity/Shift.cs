using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Shift: IEntity  //Nöbet
    {
        public int ShiftId { get; set; }
        public string? ShiftType { get; set; }
        public string? Description { get; set; }
        public List<Incident> Incidents { get; set; }  

    }
}
