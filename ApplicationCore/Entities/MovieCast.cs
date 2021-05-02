using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {

        [Key]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CastId { get; set; }
        [MaxLength(450)]
        [Required]
        public string Character { get; set; }


        [ForeignKey("MovieId")]
        public Movie movie { get; set; }
        [ForeignKey("CastId")]
        public Cast cast { get; set; }
    }
}
