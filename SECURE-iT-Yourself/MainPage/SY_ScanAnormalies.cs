using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class SY_ScanAnormalies
    {

        private List<SY_Sort_Windows> list;
        private String logName;
        private List<SY_Sort_PCap> list2;


        public SY_ScanAnormalies(List<SY_Sort_Windows> list, String logName) {
            this.list = list;
            this.logName = logName;
        }

        public SY_ScanAnormalies(List<SY_Sort_PCap> list,String logName) {
            this.list2 = list;
            this.logName = logName;
        }

        public void ScanAnormalies() {
            ScanForPortScan();
            ScanForDDoS();
        }

        private void ScanForDDoS() {
            if (list.Any())
            {
                int packetPerRoll = 3;

                if (list.Count() % 8 == 0)
                {
                    packetPerRoll = 8;
                }
                else if (list.Count() % 7 == 0)
                {
                    packetPerRoll = 7;
                }
                else if (list.Count() % 6 == 0)
                {
                    packetPerRoll = 6;
                }
                else if (list.Count % 5 == 0)
                {
                    packetPerRoll = 5;
                }
                else if (list.Count % 4 == 0)
                {
                    packetPerRoll = 4;
                }


                int packetCounter = 0;

                List<SY_Sort_Windows> perNumber = new List<SY_Sort_Windows>();

                foreach (SY_Sort_Windows item in list) {
                    if (packetCounter == packetPerRoll)
                    {
                        packetCounter = 0;

                        List<SY_Sort_Windows> retrivedPacket = new List<SY_Sort_Windows>();
                        //See which ones are receieved packets
                        foreach (SY_Sort_Windows packetItem in perNumber)
                        {
                            if (packetItem.Path.Equals("RECEIVE"))
                            {
                                retrivedPacket.Add(packetItem);
                            }
                        }

                        int skip = 0;
                        int probability = 0;
                        String prevIp = "";
                        String prevPort = "";

                        foreach (SY_Sort_Windows receivedPacket in retrivedPacket)
                        {
                            if (skip != 0)
                            {
                                if (!(receivedPacket.SRCIP.Equals(prevIp)) && receivedPacket.DSTPort.Equals(prevPort)) {
                                    probability++;
                                }

                                prevIp = receivedPacket.SRCIP;
                                prevPort = receivedPacket.DSTPort;

                            }
                            else {
                                skip = 1;
                                prevIp = receivedPacket.SRCIP;
                                prevPort = receivedPacket.DSTPort;
                            }
                        }

                        if (probability >= (packetPerRoll / 2))
                        {
                            Console.WriteLine("Port Scanned Detected");
                            DateTime StartOf = perNumber[0].dateSpecific;
                            DateTime EndTime = perNumber[perNumber.Count - 1].dateSpecific;

                            SY_Tag newTag = new SY_Tag("Possible Port Scanned", "Possible port scanned detected. Severity: High", StartOf, EndTime);

                            SY_TagDAO tagdb = new SY_TagDAO();
                            String file = tagdb.GetTaggingPath(logName);
                            List<SY_Tag> items = new List<SY_Tag>();

                            using (StreamReader r = new StreamReader(file))
                            {
                                string json = r.ReadToEnd();
                                items = JsonConvert.DeserializeObject<List<SY_Tag>>(json);
                            }

                            if (items != null && (!items.Any()))
                            {
                                items.Add(newTag);
                            }
                            else
                            {
                                items = new List<SY_Tag>();
                                items.Add(newTag);
                            }

                            using (StreamWriter newTask = new StreamWriter(file, false))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(newTask, items);
                            }

                        }

                    }
                    else {
                        perNumber.Add(item);
                        packetCounter++;
                    }

                }


            }
            else if (list2.Any()) {


            }

        }

        private void ScanForPortScan() {

            if (list.Any())
            {
                //Window Firewall Method

                //Check how much packet can checker per loop

                int packetPerRoll = 3;

                if (list.Count() % 8 == 0) {
                    packetPerRoll = 8;
                }
                else if (list.Count() % 7 == 0)
                {
                    packetPerRoll = 7;
                }
                else if (list.Count() % 6 == 0)
                {
                    packetPerRoll = 6;
                }
                else if (list.Count % 5 == 0)
                {
                    packetPerRoll = 5;
                }
                else if (list.Count % 4 == 0)
                {
                    packetPerRoll = 4;
                }


                int packetCounter = 0;

                List<SY_Sort_Windows> perNumber = new List<SY_Sort_Windows>();
                foreach (SY_Sort_Windows item in list) {
                    if (packetCounter == packetPerRoll)
                    {
                        packetCounter = 0;
                        List<SY_Sort_Windows> retrivedPacket = new List<SY_Sort_Windows>();
                        //See which ones are receieved packets
                        foreach (SY_Sort_Windows packetItem in perNumber) {
                            if (packetItem.Path.Equals("RECEIVE")) {
                                retrivedPacket.Add(packetItem);
                            }
                        }

                        int skip = 0;
                        String prevIp = "";
                        String prevPort = "";
                        int probability = 0;

                        foreach (SY_Sort_Windows receivedPacket in retrivedPacket) {
                            if (skip != 0)
                            {
                                if (receivedPacket.SRCIP.Equals(prevIp) && receivedPacket.DSTPort.Equals(prevPort)) {
                                    probability++;
                                    prevIp = receivedPacket.SRCIP;
                                    prevPort = receivedPacket.DSTPort;
                                }
                            }
                            else {
                                skip = 1;
                                prevIp = receivedPacket.SRCIP;
                                prevPort = receivedPacket.DSTPort;
                            }

                                
                        }


                        if (probability >= ((packetPerRoll / 2))) {
                            Console.WriteLine("Port Scanned Detected");
                            DateTime StartOf = perNumber[0].dateSpecific;
                            DateTime EndTime = perNumber[perNumber.Count - 1].dateSpecific;

                            SY_Tag newTag = new SY_Tag("Possible Port Scan", "Under Reconnaissance, it seems that someone is researching on how to attack your machine. Severity: Mild ", StartOf, EndTime);

                            SY_TagDAO tagdb = new SY_TagDAO();
                            String file = tagdb.GetTaggingPath(logName);
                            Console.WriteLine(file);
                            List<SY_Tag> items = new List<SY_Tag>();

                            using (StreamReader r = new StreamReader(file))
                            {
                                string json = r.ReadToEnd();
                                items = JsonConvert.DeserializeObject<List<SY_Tag>>(json);
                            }

                            if (items != null && (!items.Any()))
                            {
                                items.Add(newTag);
                            }
                            else
                            {
                                items = new List<SY_Tag>();
                                items.Add(newTag);
                            }

                            using (StreamWriter newTask = new StreamWriter(file, false))
                            {
                                JsonSerializer serializer = new JsonSerializer();
                                serializer.Serialize(newTask, items);
                            }


                        }

                    }
                    else {
                        perNumber.Add(item);
                        packetCounter++;
                    }
                }


            }
            else if (list2.Any()) {

            }

        }

    }
}
