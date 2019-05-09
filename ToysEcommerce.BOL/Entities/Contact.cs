using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysEcommerce.BOL.Entities
{
    [Table("Contact")]
    public class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar"), StringLength(50), Required()]
        public string Subject { get; set; }

        [Column(TypeName = "varchar"), StringLength(50)]
        public string NameSurname { get; set; }

        [Column(TypeName = "varchar"), StringLength(80)]
        public string MailAddress { get; set; }

        [Column(TypeName = "varchar"), StringLength(20)]
        public string OrderNo { get; set; }

        [Column(TypeName = "varchar"), StringLength(150)]
        public string FilePath { get; set; }

        [Column(TypeName = "text")]
        public string Messagge { get; set; }
    }
}