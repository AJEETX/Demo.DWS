using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.DWS.Model
{
    public class Input
    {
        public int ID { get; set; }
        public string UnitID { get; set; }
        public DateTime Date { get; set; }
        public string UnitPrice { get; set; }
    }
    public class Output
    {
        public int ID { get; set; }
        public string UnitPrice { get; set; }
    }
}
