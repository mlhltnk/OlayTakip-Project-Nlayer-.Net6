using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RoleAssignDtos
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; }   //bu role bu kullanıcıda var mı? (bu kullanıcı bu rolü içeriyor mu)
    }
}
