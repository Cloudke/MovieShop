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
        [Column(Order= 1)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int RoleId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }
        [ForeignKey("RoleId")]
        public Role role { get; set; }
    }
}
