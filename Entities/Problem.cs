using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Entities
{
    public class Problem
    {
        public String Text { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
