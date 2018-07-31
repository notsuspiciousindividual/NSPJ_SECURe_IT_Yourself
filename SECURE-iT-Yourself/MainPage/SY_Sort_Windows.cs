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
            String[] splittedLine = file.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            action = splittedLine[2];
            dateSpecific = dateComplete(splittedLine[0], splittedLine[1]);
            SRCIP = splittedLine[3];
            DSTIP = splittedLine[4];
            SRCPort = splittedLine[5];
            DSTPort = splittedLine[6];
            SizePackage = splittedLine[7];
            TCPFlag = splittedLine[8];
            TCPSyn = splittedLine[9];
            TCpack = splittedLine[10];
            TCPwin = splittedLine[11];
            ICMPType = splittedLine[12];
            icmpinfo = splittedLine[13];
            info = splittedLine[14];
            Path = splittedLine[15];


        }

        private DateTime dateComplete(String days, String timing) {
            String[] dates = days.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            String[] seconds = timing.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime organised = new DateTime(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2]), Int32.Parse(seconds[0]), Int32.Parse(seconds[1]), Int32.Parse(seconds[2]));

            return organised;

        }


    }
}
