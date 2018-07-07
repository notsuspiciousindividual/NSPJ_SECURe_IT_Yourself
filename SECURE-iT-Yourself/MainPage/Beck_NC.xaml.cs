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

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Beck_NC.xaml
    /// </summary>
    public partial class Beck_NC : Window
    {
        public Beck_NC()
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
        }
    }
}
