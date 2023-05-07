using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogMuzyczny.Entities
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Address { get; set; }

        public IList<SupplierUser> SupplierUsers { get; set; }

        public List<Album> Albums { get; set; }

    }
}
