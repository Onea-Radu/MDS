﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Product> products { get; set; }

    }
}
