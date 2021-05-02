using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        [Key]
        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }
        [Key]
        [ForeignKey("Genre")]
        [Column(Order = 1)]
        public int GenreId { get; set; }
    }
}
