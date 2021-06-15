using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual Product Product { get; set; }
        public int ProductId { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
