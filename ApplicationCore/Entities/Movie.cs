using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
   public class Movie
    {
        public int Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Title { get; set; }

        public ICollection<Genre> Genres { get; set; }



        public string? Overview { get; set; }

        [MaxLength(512)]
        public string? Tagline { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Revenue { get; set; }
        [MaxLength(2084)]
        public string? ImdbUrl { get; set; }
        [MaxLength(2084)]
        public string? TmdbUrl { get; set; }
        [MaxLength(2084)]
        public string? PosterUrl { get; set; }
        [MaxLength(2084)]
        public string? BackdropUrl { get; set; }
        [MaxLength(64)]
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }

        [NotMapped]
        public decimal? Rating { get; set; }
    }
}
