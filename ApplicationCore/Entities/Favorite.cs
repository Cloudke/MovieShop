using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
