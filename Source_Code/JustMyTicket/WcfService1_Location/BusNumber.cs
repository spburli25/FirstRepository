using System;
using System.Net;

namespace WcfService1_Location
{
    public class BusNumber
    {
        public String From { set; get; }
        public String Hop { set; get; }
        public String To { set; get; }
        public String duration { set; get; }
        public String distance { set; get; }
        public String bus_nos { set; get; }


        /*public String getName()
        {
            return this.name;
        }

        public void setName(String s)
        {
            this.name = s;
        }

        public int getNumber()
        {
            return this.number;
        }

        public void setNumber(int s)
        {
            this.number = s;
        }*/
    }
}
