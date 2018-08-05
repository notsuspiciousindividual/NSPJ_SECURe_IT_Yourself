using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Core;
using PcapDotNet.Packets;

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

            // Open the capture file
            using (PacketCommunicator communicator = selectedDevice.Open(65536,PacketDeviceOpenAttributes.Promiscuous,1000))                                  
            {
                // Read and dispatch packets until EOF is reached
                communicator.ReceivePackets(0, DispatcherHandler);
            }


        }

        private static void DispatcherHandler(Packet packet) {
            // print packet timestamp and packet length
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);

            // Print the packet
            const int LineLength = 64;
            for (int i = 0; i != packet.Length; ++i)
            {
                Console.Write((packet[i]).ToString("X2"));
                if ((i + 1) % LineLength == 0)
                    Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

        }
        
        



    }
}
