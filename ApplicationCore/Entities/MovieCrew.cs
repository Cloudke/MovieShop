using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class MovieCrew
    {
        [Key]
        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }
        [Key]
        [ForeignKey("Crew")]
        [Column(Order = 1)]
        public int CrewId { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Job { get; set; }
    }
}
