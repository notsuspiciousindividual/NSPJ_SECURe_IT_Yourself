using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainPage
{
    class SY_Sort_PCap
    {
        public int DSTIP;
        public int SRCIP;
        public String DSTPort;
        public String SRCPort;
        public String PayloadText;
        public DateTime Captured;
        public String TCPFlags;
        public String TCPSYN;
        public String TCPACK;

        public SY_Sort_PCap(String path) {

            OfflinePacketDevice selectedDevice = new OfflinePacketDevice(path);

            using (PacketCommunicator communicator = selectedDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000)) {
                communicator.ReceivePackets(0, DispatcherHandler);
            }

        }

        private void DispatcherHandler(Packet packet) {

            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff" + "length: " + packet.Length));

            const int LineLength = 64;
            for (int i = 0; i != packet.Length; i++) {
                Console.WriteLine((packet[i]).ToString("X2"));
                if ((i + 1) % LineLength == 0)
                    Console.WriteLine();
            }

            IpV4Datagram ip = packet.Ethernet.IpV4;

            
            SRCIP = (int) ip.Source.ToValue();


            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
