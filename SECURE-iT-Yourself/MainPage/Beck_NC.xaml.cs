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
using NetFwTypeLib;
using NessusClient;
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

            RunCheck();
            //run_cmd();

            //image set
            int stat = -1;
            ImageSet(stat, CurrentOverallStatImg);
            LoadProgBar();
            //checks

           

        }

        private int storedStatPort = 0;
        private int storedStatProxy = 0;
        private int storedStatFirewall = 0;
        private int storedStatICMP = 1;
        private int storedStatUpdate = 0;

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
        //private void DescRowBtn7_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow7.IsVisible == true)
        //    {
        //        DescRow7.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow7.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //private void DescRowBtn8_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow8.IsVisible == true)
        //    {
        //        DescRow8.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow8.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //private void DescRowBtn9_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow9.IsVisible == true)
        //    {
        //        DescRow9.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow9.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //private void DescRowBtn10_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow10.IsVisible == true)
        //    {
        //        DescRow10.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow10.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //private void DescRowBtn11_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow11.IsVisible == true)
        //    {
        //        DescRow11.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow11.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //private void DescRowBtn12_Click(object sender, RoutedEventArgs e)
        //{
        //    if (DescRow12.IsVisible == true)
        //    {
        //        DescRow12.Visibility = System.Windows.Visibility.Collapsed;
        //    }
        //    else
        //    {
        //        DescRow12.Visibility = System.Windows.Visibility.Visible;
        //    }
        //}
        //For Respective buttons to configure
        private void StatsRow1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing "+ConfigRow1.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            PortscanTrigger();
            int stat = this.storedStatPort;
            ImageSet(stat, PortCheckImg);
            
            wnd.Transfer(ConfigRow1.Text.ToString(), stat);
            wnd.Show();

            
            this.Close();
        }
        private void StatsRow2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow2.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            int stat = this.storedStatProxy;
            ImageSet(stat, ProxyCheckingImg);

            wnd.Transfer(ConfigRow2.Text.ToString(), stat);
            wnd.Show();
            this.Close();
        }
        private void StatsRow3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow3.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            int stat = this.storedStatFirewall;
            ImageSet(stat, FireWallImg);

            wnd.Transfer(ConfigRow3.Text.ToString(), stat);
            wnd.Show();
            this.Close();
        }
        private void StatsRow4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow4.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            int stat = this.storedStatICMP;
            ImageSet(stat, ICMPEchoImg);

            wnd.Transfer(ConfigRow4.Text.ToString(), stat);
            wnd.Show();
            this.Close();
        }
        private void StatsRow5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Showing " + ConfigRow5.Text.ToString());
            Beck_Option wnd = new Beck_Option();
            //ImageSet(stat, ICMPEchoImg);

            //wnd.Transfer(ConfigRow4.Text.ToString(), stat);
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
        //private void StatsRow7_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow7.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
        //private void StatsRow8_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow8.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
        //private void StatsRow9_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow9.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
        //private void StatsRow10_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow10.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
        //private void StatsRow11_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow11.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
        //private void StatsRow12_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Showing " + ConfigRow12.Text.ToString());
        //    Beck_Option wnd = new Beck_Option();
        //    wnd.Show();

        //    this.Close();
        //}
      

        private void RunCheck()
        {
            //Port Check Run
            PortscanTrigger();
            //Firewall Check Run
            FirewallCheck();
            //Proxy Check Run
            ProxyCheck();
            //ICMP Check Run
            ICMPCheck();

        }
       //Arraylist for Open and Closed ports
        private static ArrayList closedPort = new ArrayList();
        private static ArrayList openedPort = new ArrayList();
       
        //Port Check
        //Get Port Status UEV: User Enterable Value
        private void PortscanTrigger()
        {
            //clear list first
            openedPort.Clear();
            closedPort.Clear();
            //Ports to check         
            //Ports restricted by Online Armor Pro by default
            //Both = 7      //Both - 9      //Both - 13     //Both - 17
            //Both - 19     //TCP - 113     //UDP - 123     //TCP - 135
            //Both - 137    //Both - 138    //TCP - 139     //Both - 389
            //Both - 445    //UDP - 500     //UDP - 520     //TCP - 1002
            //TCP - 1024    //TCP - 1025    //TCP - 1026    //TCP - 1027
            //TCP - 1028    //TCP - 1029    //TCP - 1030    //TCP - 1433
            //TCP - 1444    //UDP - 1701    //TCP - 1720    //TCP - 1723
            //TCP - 2869    //UDP - 4500
            GetAvailablePort(7);
            GetAvailablePort(9);
            GetAvailablePort(13);
            GetAvailablePort(17);
            GetAvailablePort(19);
            GetAvailablePort(113);
            GetAvailablePort(123);
            GetAvailablePort(135);
            GetAvailablePort(137);
            GetAvailablePort(138);
            GetAvailablePort(139);
            GetAvailablePort(389);
            GetAvailablePort(445);
            GetAvailablePort(500);
            GetAvailablePort(520);
            GetAvailablePort(1002);
            GetAvailablePort(1024);
            GetAvailablePort(1025);
            GetAvailablePort(1026);
            GetAvailablePort(1027);
            GetAvailablePort(1028);
            GetAvailablePort(1029);
            GetAvailablePort(1030);
            GetAvailablePort(1433);
            GetAvailablePort(1444);
            GetAvailablePort(1701);
            GetAvailablePort(1720);
            GetAvailablePort(1723);
            GetAvailablePort(2869);
            GetAvailablePort(4500);

            String PortStatReturn = "Checked and are Not Recommended to be Open: ";
            foreach (int i in openedPort)
            {
                Console.WriteLine("Available: " + i);
                PortStatReturn += " " + i;
            }
            foreach (int i in closedPort)
            {
                Console.WriteLine("Not Available: " + i);
            }
            if (closedPort.Count == 30)
            {
                this.storedStatPort = 1;
            }
            else if (closedPort.Count >= 10)
            {
                storedStatPort = 0;
                MessageBox.Show(PortStatReturn);
            }
            else
            {
                MessageBox.Show(PortStatReturn);
                storedStatPort = -1;
            }
            ImageSet(storedStatPort, PortCheckImg);
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
        //FireWall Check
        private void FirewallCheck()
        {
            //To reference to windows firewall scripting
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr", false);
            INetFwMgr mgr = (INetFwMgr)Activator.CreateInstance(NetFwMgrType);

            //Checking part
            bool Firewallenabled = mgr.LocalPolicy.CurrentProfile.FirewallEnabled;

            if (Firewallenabled == true)
            {
                storedStatFirewall = 1;
            }
            else
            {
                storedStatFirewall = -1;
            }
            ImageSet(storedStatFirewall, FireWallImg);
            MessageBox.Show("FW Status: " + Firewallenabled);
            //try
            //{
            //    String FWCheckArgs = "/C netsh advfirewall show allprofiles";
            //    Process FWCheck = new Process
            //    {
            //        StartInfo = new ProcessStartInfo()
            //        {
            //            CreateNoWindow = true,
            //            UseShellExecute = false,
            //            FileName = "cmd.exe",
            //            WindowStyle = ProcessWindowStyle.Hidden,
            //            Arguments = FWCheckArgs,
            //            RedirectStandardOutput = true,
            //            RedirectStandardError = true,
            //            Verb = "runas"
            //        }
            //    };
            //    FWCheck.Start();
            //    String FWOutput = FWCheck.StandardOutput.ReadToEnd();

            //    FWCheck.WaitForExit(2000);
            //    //MessageBox.Show(FWOutput);

            //    List<String> FWOut = FWOutput.Split('\n').ToList();
            //    String FWString1 = FWOut.ElementAt(3);
            //    String FWString2 = FWOut.ElementAt(20);
            //    String FWString3 = FWOut.ElementAt(37);
            //    //MessageBox.Show("Check: " + FWString1);
            //    //MessageBox.Show("Check: " + FWString2);
            //    //MessageBox.Show("Check: " + FWString3);

            //    List<String> FWOut1 = FWString1.Split(' ').ToList();

            //    string text = File.ReadAllText("../../Resources\\Beck_Text/fw.txt");
            //    List<String> stext = text.Split('\n').ToList();
            //    String CompileVal = stext.ElementAt(3);

            //    //MessageBox.Show("Check: " + CompileVal);

            //    int counter = 0;
            //    if (FWString1.Equals(CompileVal))
            //    {
            //        counter++;
            //    }

            //    if (FWString2.Equals(CompileVal))
            //    {
            //        counter++;
            //    }

            //    if (FWString3.Equals(CompileVal))
            //    {
            //        counter++;
            //    }

            //    if (counter == 3)
            //    {
            //        storedStatFirewall = 1;
            //    }
            //    else if (counter == 2)
            //    {
            //        storedStatFirewall = 0;
            //    }
            //    else
            //    {
            //        storedStatFirewall = -1;
            //    }
            //}
            //catch (Exception s)
            //{
            //    MessageBox.Show("Error: " + s.StackTrace);
            //}

        }
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
                //MessageBox.Show("process proc sucess");
                if (proc.HasExited)
                {
                    output = ProxyOutput.ReadToEnd();
                    //MessageBox.Show("process output update sucess");
                }
                ProxyOutput.Close();
                string text = File.ReadAllText("../../Resources\\Beck_Text/proxy.txt");
                //MessageBox.Show("\""+output+"\"");
                if (output.Equals(text))
                {
                    //MessageBox.Show("No web proxy");
                    this.storedStatProxy = 0;
                }
                else 
                {
                    this.storedStatProxy = 1;
                }
                ImageSet(this.storedStatProxy, ProxyCheckingImg);
            }
            catch (Exception pe)
            {
                MessageBox.Show("Error: " + pe.Message);
            }
        }
        ////Check for Web Proxy
        //private void CheckWebProxy()
        //{
        //    try
        //    {
        //        WebProxy proxy = (WebProxy)WebRequest.DefaultWebProxy;
        //        if (proxy.Address.AbsoluteUri != string.Empty)
        //        {
        //            MessageBox.Show("Proxy URL: " + proxy.Address.AbsoluteUri);
        //        }
        //        else
        //        {
        //            MessageBox.Show("No proxy url");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //        MessageBox.Show(e.StackTrace);
        //    }
        //}

        //ICMP Echo Check
        private void ICMPCheck()
        {
            //ICMP checking portion
            //IPStatus iPStatus = new IPStatus();
            //if (iPStatus.ToString() == "Success")
            //{
            //    //ICMP Echo is on: Not Ideal
            //    this.storedStatICMP = 1;
            //}
            //else
            //{
            //    //ICMP Echo is off: Ideal
            //    this.storedStatICMP = 0;
            //}
            ImageSet(this.storedStatICMP, ICMPEchoImg);
        }

        //Update on click settings

        //private void installupdatesyncwithinfo()
        //{
        //    Updatecheckinfo info = null;

        //    if (applicationdeployment.isnetworkdeployed)
        //    {
        //        applicationdeployment ad = applicationdeployment.currentdeployment;

        //        try
        //        {
        //            info = ad.checkfordetailedupdate();

        //        }
        //        catch (deploymentdownloadexception dde)
        //        {
        //            messagebox.show("the new version of the application cannot be downloaded at this time. \n\nplease check your network connection, or try again later. error: " + dde.message);
        //            return;
        //        }
        //        catch (invaliddeploymentexception ide)
        //        {
        //            messagebox.show("cannot check for a new version of the application. the clickonce deployment is corrupt. please redeploy the application and try again. error: " + ide.message);
        //            return;
        //        }
        //        catch (invalidoperationexception ioe)
        //        {
        //            messagebox.show("this application cannot be updated. it is likely not a clickonce application. error: " + ioe.message);
        //            return;
        //        }

        //        if (info.updateavailable)
        //        {
        //            boolean doupdate = true;

        //            if (!info.isupdaterequired)
        //            {
        //                dialogresult dr = messagebox.show("an update is available. would you like to update the application now?", "update available", messageboxbuttons.okcancel);
        //                if (!(dialogresult.ok == dr))
        //                {
        //                    doupdate = false;
        //                }
        //            }
        //            else
        //            {
        //                // display a message that the app must reboot. display the minimum required version.
        //                messagebox.show("this application has detected a mandatory update from your current " +
        //                    "version to version " + info.minimumrequiredversion.tostring() +
        //                    ". the application will now install the update and restart.",
        //                    "update available", messageboxbuttons.ok,
        //                    messageboxicon.information);
        //            }

        //            if (doupdate)
        //            {
        //                try
        //                {
        //                    ad.update();
        //                    messagebox.show("the application has been upgraded, and will now restart.");
        //                    application.restart();
        //                }
        //                catch (deploymentdownloadexception dde)
        //                {
        //                    messagebox.show("cannot install the latest version of the application. \n\nplease check your network connection, or try again later. error: " + dde);
        //                    return;
        //                }
        //            }
        //        }
        //    }

        /*Severity Check*/
        //public string run_cmd(string cmd, string args)
        //{
        //    ProcessStartInfo start = new ProcessStartInfo();
        //    start.FileName = "PATH_TO_PYTHON_EXE";
        //    start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args);
        //    start.UseShellExecute = false;// Do not use OS shell
        //    start.CreateNoWindow = true; // We don't need new window
        //    start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
        //    start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
        //    using (Process process = Process.Start(start))
        //    {
        //        using (StreamReader reader = process.StandardOutput)
        //        {
        //            string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
        //            string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
        //            return result;
        //        }
        //    }
        //}

    }
}
