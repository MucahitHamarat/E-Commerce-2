using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key,Column(Order =1)]
        public int ProductID { get; set; }
        [Key, Column(Order = 2)]
        public int CategoryID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }
}