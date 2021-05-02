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
        [Column(Order = 1)]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }

        [ForeignKey("MovieId")]
        public Movie movie { get; set; }
        [ForeignKey("UserId")]
        public User user { get; set; }

#nullable enable
        public string? ReviewText { get; set; }


    }
}
