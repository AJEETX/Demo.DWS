using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DWS.Model
{
    public class Input
    {
        public int ID { get; set; }
        [Required]
        public string UnitID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string UnitPrice { get; set; }
    }
    public class Output
    {
        public int ID { get; set; }
        public string UnitPrice { get; set; }
    }
}
