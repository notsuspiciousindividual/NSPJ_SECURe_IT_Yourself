using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class SY_Sort_Windows
    {
        public DateTime dateSpecific { get; set; }
        public String action { get; set; }
        public String protocol { get; set; }
        public String SRCIP { get; set; }
        public String DSTIP { get; set; }
        public String SRCPort { get; set; }
        public String DSTPort { get; set; }
        public String SizePackage { get; set; }
        public String TCPFlag { get; set; }
        public String TCPSyn { get; set; }
        public String TCpack { get; set; }
        public String TCPwin { get; set; }
        public String ICMPType { get; set; }
        public String icmpinfo { get; set; }
        public String info { get; set; }
        public String Path { get; set; }

        public SY_Sort_Windows(String file) {
            String[] splittedLine = file.Split(new char[] { ' ' });
            
            action = splittedLine[2];
            dateSpecific = dateComplete(splittedLine[0], splittedLine[1]);
            protocol = splittedLine[3];
            SRCIP = splittedLine[4];
            DSTIP = splittedLine[5];
            SRCPort = splittedLine[6];
            DSTPort = splittedLine[7];
            SizePackage = splittedLine[8];
            TCPFlag = splittedLine[9];
            TCPSyn = splittedLine[10];
            TCpack = splittedLine[11];
            TCPwin = splittedLine[12];
            ICMPType = splittedLine[13];
            icmpinfo = splittedLine[14];
            info = splittedLine[15];
            Path = splittedLine[16];


        }

        private DateTime dateComplete(String days, String timing) {
            String[] dates = days.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            String[] seconds = timing.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime organised = new DateTime(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2]), Int32.Parse(seconds[0]), Int32.Parse(seconds[1]), Int32.Parse(seconds[2]));

            return organised;

        }

        //public List<String> getData() {
        //    List<String> list = new List<String>();

        //    list[0] =  dateSpecific.Year.ToString() + "-" + dateSpecific.Month.ToString() + "-" + dateSpecific.Day.ToString();
        //    list[1] = dateSpecific.Hour.ToString() + ":" + dateSpecific.Minute.ToString() + ":" + dateSpecific.Second.ToString();
        //    list[2];
        //    list[2];
        //    list[2];
        //}


    }
}
