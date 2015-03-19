using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusWCF
{
    public class BusNumber
    {
        public String From { set; get; }
        public String Hop { set; get; }
        public String To { set; get; }
        public String duration { set; get; }
        public String distance { set; get; }
        public String bus_nos { set; get; }
    }
}