using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmagClone.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        // Todo stock/Reviews
        public Guid SellerId { get; set; }
        public virtual User Seller { get; set; }

        public virtual ICollection<Review> Reviews { get; set;}
    }
}
