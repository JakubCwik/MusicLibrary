using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KatalogMuzyczny.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("username")]
        public string Login { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        public IList<SupplierUser> SupplierUsers { get; set; }
    }
}
