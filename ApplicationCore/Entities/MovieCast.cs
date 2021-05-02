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

        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [ForeignKey("Cast")]
        [Column(Order = 1)]
        public int CastId { get; set; }
        [MaxLength(450)]
        [Required]
        public string Character { get; set; }
    }
}
