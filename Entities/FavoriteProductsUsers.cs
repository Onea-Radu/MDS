using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmagClone.Entities
{
    public class FavoriteProductsUsers
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        [Required]
        public User User { get; set; }

        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
    }
}
