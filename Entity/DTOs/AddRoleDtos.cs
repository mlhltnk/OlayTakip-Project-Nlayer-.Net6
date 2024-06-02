using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class AddRoleDtos
    {
        [Required(ErrorMessage = " Lütfen Rol Adı Giriniz")]
        public string name { get; set; }
    }
}
