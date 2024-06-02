using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AppUser : IdentityUser<int> ,IEntity //key değeri int olsun
                                              //appuser ile identity'i ilişkilendirdik.
    {
        public string NameSurname { get; set; }

    }
}
