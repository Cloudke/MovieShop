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
        [Column(Order = 1)]
        public int MovieId { get; set; }
        
        [Key]
        [Column(Order = 1)]
        public int GenreId { get; set; }


        [ForeignKey("MovieId")]
        public Movie movie { get; set; }
        [ForeignKey("GenreId")]
        public Genre genre { get; set; }
    }
}
