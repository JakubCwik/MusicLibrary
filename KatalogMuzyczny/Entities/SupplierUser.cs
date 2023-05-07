using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogMuzyczny.Entities
{
    public class SupplierUser
    {
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public Supplier Supplier { get; set; }
        public User User { get; set; }
    }
}
