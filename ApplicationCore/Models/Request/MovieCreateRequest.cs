using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieCreateRequestModel
    {
        public String title { get; set; }
        public decimal budget { get; set; }
        public decimal revenue { get; set; }
    }
}
