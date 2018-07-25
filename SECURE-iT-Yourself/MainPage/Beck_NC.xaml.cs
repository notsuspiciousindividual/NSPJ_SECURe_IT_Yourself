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
using System.Windows.Media.Animation;
using System.Collections;
using System.Diagnostics;
using System.IO;
//using WUApiLib;


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

            //image set
            int stat = -1;
            ImageSet(stat, CurrentOverallStatImg);
            LoadProgBar();
            //checks
            ICMPCheck();
            openedPort.Clear();
            closedPort.Clear();
            PortscanTrigger(2000);
            if (openedPort.Count >= 20)
            {
                stat = 1;
                ImageSet(stat, PortCheckImg);
            }
            else if (openedPort.Count >= 10)
            {
                stat = 0;
                ImageSet(stat, PortCheckImg);
            }
            else
            {
                stat = -1;
                ImageSet(stat, PortCheckImg);
            }
            this.storedStat = stat;
            ProxyCheck();

        }

        private int storedStat = 0;

        //Back clicked
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi");
        }
        //Image Setting
        private void ImageSet(int Status, Image img)
        {
            if (Status.Equals(1))
            {
                try
                {
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Beck_Images/green-smiley-face-md.png"));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problem " + e);
                }
            }
            else if (Status.Equals(0))
            {
                try
                {
                    //Uri uri = new Uri("pack://application:,,,/Resources/Beck_Images/Background.jpg");
                    //BitmapImage bi = new BitmapImage(uri);
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Beck_Images/yellow-neutral-face-md.png"));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problem " + e);
                }
            }
            else if (Status.Equals(-1))
            {
                try
                {
                    //Uri uri = new Uri("pack://application:,,,/Resources/Beck_Images/Background.jpg");
                    //BitmapImage bi = new BitmapImage(uri);
                    img.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Beck_Images/red-smiley-face-md.png"));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problem " + e);
                }
            }
        }
        //Progress bar
        private void LoadProgBar()
        {
            //determine the double in progress
            double configPercent = 50;

            try
            {
                SetPercent(OverallPB, configPercent);
            }
            catch (Exception e)
            {
                MessageBox.Show("Problem " + e);
            }
            
        }
        //Progress bar setting updating method
        private TimeSpan duration = TimeSpan.FromSeconds(2);
        public void SetPercent(ProgressBar progressBar, double percentage)
        {
            DoubleAnimation animation = new DoubleAnimation(percentage, duration);
            progressBar.BeginAnimation(ProgressBar.ValueProperty, animation);

        }

        //For Description
        private void DescRowBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow1.IsVisible == true)
            {
                DescRow1.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow1.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow2.IsVisible == true)
            {
                DescRow2.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow2.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn3_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow3.IsVisible == true)
            {
                DescRow3.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow3.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn4_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow4.IsVisible == true)
            {
                DescRow4.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow4.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn5_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow5.IsVisible == true)
            {
                DescRow5.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow5.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn6_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow6.IsVisible == true)
            {
                DescRow6.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow6.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn7_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow7.IsVisible == true)
            {
                DescRow7.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow7.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn8_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow8.IsVisible == true)
            {
                DescRow8.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow8.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn9_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow9.IsVisible == true)
            {
                DescRow9.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow9.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn10_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow10.IsVisible == true)
            {
                DescRow10.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow10.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn11_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow11.IsVisible == true)
            {
                DescRow11.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow11.Visibility = System.Windows.Visibility.Visible;
            }
        }
        private void DescRowBtn12_Click(object sender, RoutedEventArgs e)
        {
            if (DescRow12.IsVisible == true)
            {
                DescRow12.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                DescRow12.Visibility = System.Windows.Visibility.Visible;
            }
        }
        //For Respective buttons to configure
        private void StatsRow1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing "+ConfigRow1.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            PortscanTrigger(2000);
            int stat = this.storedStat;
            ImageSet(stat, PortCheckImg);
            
            wnd.Transfer(ConfigRow1.Text.ToString(), stat);
            wnd.Show();

            
            this.Close();
        }
        private void StatsRow2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow2.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow3.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow4.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow5.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow6.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow7_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow7.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow8_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow8.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow9_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow9.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow10_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow10.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow11_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow11.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
        private void StatsRow12_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow12.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            wnd.Show();

            this.Close();
        }
      

        private void Initials()
        {
            //Check for Web Proxy
            

            //Check for ports that are open
        }
        //Check for Web Proxy
        private void CheckWebProxy()
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
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show(e.StackTrace);
            }
        }
       
        //Arraylist for Open and Closed ports
        private static ArrayList closedPort = new ArrayList();
        private static ArrayList openedPort = new ArrayList();
        //Get Port Status
        private void PortscanTrigger(int UEV)
        {
            //User Entered Value
            for (int i = 1; i < UEV; i++)
            {
                GetAvailablePort(i);
            }

            foreach (int i in openedPort)
            {
                Console.WriteLine("Available: " + i);
            }
            foreach (int i in closedPort)
            {
                Console.WriteLine("Not Available: " + i);
            }
            Console.ReadLine();
        }
        private static int GetAvailablePort(int startingPort)
        {
            IPEndPoint[] endPoints;
            List<int> portArray = new List<int>();
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

            //get active connections
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            portArray.AddRange(from n in connections where n.LocalEndPoint.Port >= startingPort select n.LocalEndPoint.Port);

            //get active tcp listners - WCF service listening in tcp
            endPoints = properties.GetActiveTcpListeners();
            portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);

            //get active udp listeners
            endPoints = properties.GetActiveUdpListeners();
            portArray.AddRange(from n in endPoints where n.Port >= startingPort select n.Port);

            portArray.Sort();

            for (int i = startingPort; i < UInt16.MaxValue; i++)
            {
                if (!portArray.Contains(i))
                {
                    closedPort.Add(i);
                    return i;
                }
                else
                {
                    openedPort.Add(i);
                    return 0;
                }
            }

            return 0;
        }

        // Update on click settings
        //private void installupdatesyncwithinfo()
        //{
        //    updatecheckinfo info = null;

        //  if (applicationdeployment.isnetworkdeployed)
        //  {
        //      applicationdeployment ad = applicationdeployment.currentdeployment;

        //      try
        //      {
        //          info = ad.checkfordetailedupdate();

        //      }
        //      catch (deploymentdownloadexception dde)
        //      {
        //          messagebox.show("the new version of the application cannot be downloaded at this time. \n\nplease check your network connection, or try again later. error: " + dde.message);
        //          return;
        //      }
        //      catch (invaliddeploymentexception ide)
        //      {
        //          messagebox.show("cannot check for a new version of the application. the clickonce deployment is corrupt. please redeploy the application and try again. error: " + ide.message);
        //          return;
        //      }
        //      catch (invalidoperationexception ioe)
        //      {
        //          messagebox.show("this application cannot be updated. it is likely not a clickonce application. error: " + ioe.message);
        //          return;
        //      }

        //      if (info.updateavailable)
        //      {
        //          boolean doupdate = true;

        //          if (!info.isupdaterequired)
        //          {
        //              dialogresult dr = messagebox.show("an update is available. would you like to update the application now?", "update available", messageboxbuttons.okcancel);
        //              if (!(dialogresult.ok == dr))
        //              {
        //                  doupdate = false;
        //              }
        //          }
        //          else
        //          {
        //              // display a message that the app must reboot. display the minimum required version.
        //              messagebox.show("this application has detected a mandatory update from your current " +
        //                  "version to version " + info.minimumrequiredversion.tostring() +
        //                  ". the application will now install the update and restart.",
        //                  "update available", messageboxbuttons.ok,
        //                  messageboxicon.information);
        //          }

        //          if (doupdate)
        //          {
        //              try
        //              {
        //                  ad.update();
        //                  messagebox.show("the application has been upgraded, and will now restart.");
        //                  application.restart();
        //              }
        //              catch (deploymentdownloadexception dde)
        //              {
        //                  messagebox.show("cannot install the latest version of the application. \n\nplease check your network connection, or try again later. error: " + dde);
        //                  return;
        //              }
        //          }
        //      }
        //  }

        //protected override void (eventargs e)
        //{
        //    base.onload(e);
        //    updatesession usession = new updatesession();
        //    iupdatesearcher usearcher = usession.createupdatesearcher();
        //    usearcher.online = false;
        //    try
        //    {
        //        isearchresult sresult = usearcher.search("isinstalled=1 and ishidden=0");
        //        textbox1.text = "found " + sresult.updates.count + " updates" + environment.newline;
        //        foreach (iupdate update in sresult.updates)
        //        {
        //            textbox1.appendtext(update.title + environment.newline);
        //        }
        //    }
        //    catch (exception ex)
        //    {
        //        console.writeline("something went wrong: " + ex.message);
        //    }
        //}
        //Proxy Check
        private void ProxyCheck()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = false,
                UseShellExecute = false,
                FileName = "netsh",
                WindowStyle = ProcessWindowStyle.Normal,
                Arguments = "winhttp show proxy",
                RedirectStandardOutput = true
            };
            Process proc = Process.Start(startInfo);

            try
            {
                StreamReader ProxyOutput = proc.StandardOutput;
                proc.WaitForExit(2000);
                string output = "";
                MessageBox.Show("process proc sucess");

                if (proc.HasExited)
                {
                    output = ProxyOutput.ReadToEnd();
                    MessageBox.Show("process output update sucess");

                }
                ProxyOutput.Close();
                MessageBox.Show(output);
            }
            catch (Exception pe)
            {
                MessageBox.Show("Error: " + pe.Message);
            }


            //ProcessStartInfo startInfo = new ProcessStartInfo
            //{
            //    CreateNoWindow = false,
            //    UseShellExecute = false,
            //    WindowStyle = ProcessWindowStyle.Hidden,
            //    FileName = "netsh",
            //    Arguments = "winhttp show proxy",
            //    RedirectStandardOutput = true
            //};
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //Process.Start(startInfo);

        }

        //ICMP Echo Check
        private void ICMPCheck()
        {
            String Text = "";
            IPStatus iPStatus = new IPStatus();
            Text += "IP status: " + iPStatus;
            if (iPStatus.ToString() == "Success")
            {
                //Not Ideal
                Text += "\nICMP Echo is on";
            }
            else
            {
                //Ideal
                Text += "\nICMP Echo is off";
            }


            String strHostName = "";
            // Get the host name of local machine.
            strHostName = Dns.GetHostName();
            String Printable = "Local Machine's Host Name: " + strHostName;

            // Then using host name, get the IP address list..
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            String IPAdd = addr[addr.Length - 1].ToString();

            Printable += "\nIP Address: "+IPAdd;

            //for (int i = 0; i < addr.Length; i++)
            //{
            //    Printable += "\nIP Address "+i+": "+addr[i].ToString();
            //}
            MessageBox.Show(Printable);
            //IPAddress iPAddress = new IPAddress();
            //IPEndPoint iPEndPoint = new IPEndPoint();
        }
       
    }
}
