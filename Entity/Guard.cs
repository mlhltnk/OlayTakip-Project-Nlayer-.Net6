using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Guard:IEntity  //Nöbetçi
    {
        public int GuardId { get; set; }
        public string GuardName{ get; set; }
        public string? Mail{ get; set; }

        public bool? Status { get; set; }

        public List<Incident> Incidents { get; set; }  
    }
}
