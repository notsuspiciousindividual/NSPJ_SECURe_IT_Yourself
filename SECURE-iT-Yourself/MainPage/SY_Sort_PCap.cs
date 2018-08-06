using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;

namespace MainPage
{
    class SY_Sort_PCap
    {
        public String DSTIP;
        public String SRCIP;
        public String DSTPort;
        public String SRCPort;
        public String PayloadText=" ";
        public DateTime Captured;
        public String Protocol;
        public String TCPFlags=" ";
        public String TCPSYN=" ";
        public String TCPACK=" ";
        public List<SY_Sort_PCap> list;
        public String TCPWin;


        public SY_Sort_PCap(String path) {
            OfflinePacketDevice selectedDevice = new OfflinePacketDevice(path);

            list = new List<SY_Sort_PCap>();

            // Open the capture file
            using (PacketCommunicator communicator = selectedDevice.Open(65536,PacketDeviceOpenAttributes.Promiscuous,1000))                                  
            {
                // Read and dispatch packets until EOF is reached
                communicator.ReceivePackets(0, DispatcherHandler);
            }


        }

        public SY_Sort_PCap(String DSTIP, String SRCIP, String DSTPort, String SRCPort, DateTime Captured, String Protocol, String payload) {
            this.DSTIP = DSTIP;
            this.SRCIP = SRCIP;
            this.DSTPort = DSTPort;
            this.SRCPort = SRCPort;
            this.Captured = Captured;
            this.Protocol = Protocol;
            this.PayloadText = payload;
        }

        public SY_Sort_PCap(String DSTIP, String SRCIP, String DSTPort, String SRCPort, DateTime Captured, String Protocol, String payload, String TCPFlag, String TCPSYN, String TCPAck, String TCPFlags, String TCPWin) {
            this.DSTIP = DSTIP;
            this.SRCIP = SRCIP;
            this.DSTPort = DSTPort;
            this.SRCPort = SRCPort;
            this.Captured = Captured;
            this.Protocol = Protocol;
            this.PayloadText = payload;
            this.TCPSYN = TCPSYN;
            this.TCPACK = TCPAck;
            this.TCPFlags = TCPFlags;
            this.TCPWin = TCPWin;

        }

        private void DispatcherHandler(Packet packet) {
            // print packet timestamp and packet length
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + packet.Length);

            // Print the packet
            IpV4Address ipV4 = packet.Ethernet.IpV4.Source;
            SRCIP = ipV4.ToString();

            ipV4 = packet.Ethernet.IpV4.Destination;
            DSTIP = ipV4.ToString();

            String protocol = getProtocol(packet);

            IpV4Datagram ip4 = packet.Ethernet.IpV4;
            Datagram datagram = null;
            UdpDatagram udp = null;
            TcpDatagram tcp = null;

            if (protocol.Equals("TCP"))
            {
                DSTPort = packet.Ethernet.IpV4.Tcp.DestinationPort.ToString();
                SRCPort = packet.Ethernet.IpV4.Tcp.SourcePort.ToString();
                TCPSYN = packet.Ethernet.IpV4.Tcp.SequenceNumber.ToString();
                TCPACK = packet.Ethernet.IpV4.Tcp.AcknowledgmentNumber.ToString();
                TCPFlags = DetermineTCPFlag(packet);
                ushort TCPWinShort = packet.Ethernet.IpV4.Tcp.Window;
                TCPWin = ConvertLinearToString(TCPWinShort);


                tcp = ip4.Tcp;
                datagram = tcp.Payload;

            }
            else if (protocol.Equals("UDP")) {

                DSTPort = packet.Ethernet.IpV4.Udp.DestinationPort.ToString();
                SRCPort = packet.Ethernet.IpV4.Udp.SourcePort.ToString();
                TCPACK = "-";
                TCPFlags = "-";
                TCPSYN = "-";
                TCPWin = "-";
                udp = ip4.Udp;
                datagram = udp.Payload;
            }


            
            

            Captured = packet.Timestamp;
            byte[] rx_payload = null;

            if (datagram != null) {
                int payloadLength = datagram.Length;
                using (MemoryStream ms = datagram.ToMemoryStream())
                {
                    rx_payload = new byte[payloadLength];
                    ms.Read(rx_payload, 0, payloadLength);
                }
            }
            if ( rx_payload != null)
            {
                PayloadText = Encoding.UTF8.GetString(rx_payload, 0, rx_payload.Length);
            }
            else {
                PayloadText = "Empty";
            }

            if (protocol.Equals("TCP"))
            {
                list.Add(new SY_Sort_PCap(DSTIP, SRCIP, DSTPort, SRCPort, Captured, Protocol, PayloadText, TCPFlags, TCPSYN, TCPACK, TCPFlags, TCPWin));
            }
            else if (protocol.Equals("UDP")) {
                list.Add(new SY_Sort_PCap(DSTIP, SRCIP, DSTPort, SRCPort, Captured, Protocol, PayloadText));
            }
            
        }

        public List<SY_Sort_PCap> getList() {
            return list;
        }

        private String getProtocol(Packet packet) {
            String protocol = "TCP";

            if (packet.IpV4.Protocol == IpV4Protocol.Udp) {
                protocol = "UDP";
            }


            return protocol;

        }

        private string DetermineTCPFlag(Packet packet) {
            string flag = "";


            if (packet.Ethernet.IpV4.Tcp.IsAcknowledgment)
            {
                flag = "ACK";
            }
            else if (packet.Ethernet.IpV4.Tcp.IsFin)
            {
                flag = "FIN";
            }
            else if (packet.Ethernet.IpV4.Tcp.IsSynchronize)
            {
                flag = "SYN";
            }
            else if (packet.Ethernet.IpV4.Tcp.IsReset)
            {
                flag = "RST";
            }
            else if (packet.Ethernet.IpV4.Tcp.IsPush) {
                flag = "PUSH";
            }



            return flag;
        }

        private static string ConvertLinearToString(ushort data)
        {
            var n = GetBitRange(data, 16, 5);
            var y = GetBitRange(data, 21, 11);
            var value = y * Math.Pow(2, n);
            return value.ToString();
        }

        private static int GetBitRange(int data, int offset, int count)
        {
            return data << offset >> (32 - count);
        }




    }
}
