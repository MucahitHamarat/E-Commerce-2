using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Product")]
    public class Product
    {
        public int ID { get; set; }

        [Column(TypeName ="varchar"),StringLength(100),Required()]
        public string Name { get; set; }

        [Column(TypeName = "varchar"), StringLength(250)]
        public string Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "varchar"), StringLength(160)]
        public string Picture { get; set; }

        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
