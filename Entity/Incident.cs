using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Incident: IEntity  //Olay
    {
        public int IncidentId { get; set; }
        public string IncidentName { get; set; }
        public DateTime IncidentDatetime { get; set; }
        //public DateTime? ResulationDatetime { get; set; }
        public string Description { get; set; }

        public Shift Shift { get; set; }    

        public int ShiftId { get; set; }    


        public Guard Guard { get; set; }     
       
        public int GuardId { get; set; }     
    }
}
