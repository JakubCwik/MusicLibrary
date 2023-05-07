using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogMuzyczny.Entities
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(20)]
        public string Version { get; set; }

        [Required]
        public int Year { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Song> Songs { get; set; }
    }
}
