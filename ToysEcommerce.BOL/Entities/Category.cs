using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Required()]
        public string Name { get; set; }

        public int CatID { get; set; }
        public int Order { get; set; }

        public virtual ICollection<ProductCategory> ProductCategory { get; set; }
    }
}