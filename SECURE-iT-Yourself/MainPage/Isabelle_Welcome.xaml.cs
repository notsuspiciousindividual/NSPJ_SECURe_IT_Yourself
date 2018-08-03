using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Net;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Isabelle_Welcome.xaml
    /// </summary>
    public partial class Isabelle_Welcome : Window
    {
        public Isabelle_Welcome()
        {

            InitializeComponent();

        }
        //Back
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
            Initials();
        }
        
        //respective buttons to configure
        private void StatsRow1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }

        private void StatsRow2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow6_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StatsRow7_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow8_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StatsRow9_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StatsRow10_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }

        private void StatsRow11_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }

        private void StatsRow12_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }

        private void Initials()
        {
            //Check for ports that are open


            //Check for Web Proxy
            try
            {
                WebProxy proxy = (WebProxy)WebRequest.DefaultWebProxy;
                if (proxy.Address.AbsoluteUri != string.Empty)
                {
                    Console.WriteLine("Proxy URL: " + proxy.Address.AbsoluteUri);
                }
                else
                {
                    Console.WriteLine("No proxy url");
                }
            }
            catch (Exception e){
                Console.WriteLine(e.StackTrace);
                MessageBox.Show(e.StackTrace);
            }

            //
        }
        public static int GetAvailablePort(int startingPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();

            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            //getting active connections
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            portArray.AddRange(from n in connections
                               where n.LocalEndPoint.Port >= startingPort
                               select n.LocalEndPoint.Port);

            //getting active tcp listners - WCF service listening in tcp
            endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            //getting active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints
                               where n.Port >= startingPort
                               select n.Port);

            portArray.Sort();

            for (int i = startingPort; i < UInt16.MaxValue; i++)
                if (!portArray.Contains(i))
                    return i;

            return 0;
        }
    }
}
