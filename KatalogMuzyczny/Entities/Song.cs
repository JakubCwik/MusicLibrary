using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatalogMuzyczny.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public int TrackNumber { get; set; }

        public TimeSpan SongDuration { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
