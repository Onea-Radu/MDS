using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmagClone.Entities
{
    public class User : IdentityUser<Guid>
    {


        [MinLength(6)]
        [MaxLength(200)]
        public String Name { get; set; }

        public ICollection<Product> cart { get; set; }

    }
}
