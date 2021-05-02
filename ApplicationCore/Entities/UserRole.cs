using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
   public class UserRole
    {
        [Key]
        [ForeignKey("User")]
        [Column(Order= 1)]
        public int UserId { get; set; }

        [Key]
        [ForeignKey("Role")]
        [Column(Order = 1)]
        public int RoleId { get; set; }
    }
}
