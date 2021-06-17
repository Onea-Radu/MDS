using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmagClone.Entities
{
    public class User : IdentityUser<Guid>
    {


        [MinLength(6)]
        [MaxLength(200)]
        public String Name { get; set; }

        [ForeignKey("SellerId")]
        public ICollection<Product> SellingProducts { get; set; }
        public ICollection<CartProductsUsers> cartProducts { get; set; }
        public ICollection<FavoriteProductsUsers> favoriteProducts { get; set; }

    }
}
