using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Admin")]
    public class Admin
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(50)]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar"), StringLength(30)]
        public string UserName { get; set; }

        [Column(TypeName = "varchar"), StringLength(20)]
        public string Password { get; set; }
    }
}