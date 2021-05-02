using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PurchaseNumber { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }


    }
}
