using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Brand")]
    public class Brand
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Required()]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}