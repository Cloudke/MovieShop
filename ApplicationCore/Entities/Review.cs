using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Review
    {
        [Key]
        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [ForeignKey("User")]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }
#nullable enable
        public string? ReviewText { get; set; }
    }
}
