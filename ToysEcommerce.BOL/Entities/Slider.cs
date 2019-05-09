using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Slider")]
    public class Slider
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Required()]
        public string Name { get; set; }

        [Column(TypeName = "varchar"), StringLength(150)]
        public string Picture { get; set; }

        [Column(TypeName = "varchar"), StringLength(150)]
        public string Link { get; set; }

        public int Order { get; set; }
    }
}