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
            //get the open ports first
            openedPort.Clear();
            closedPort.Clear();

            //get port number first
            String GPN = "";
            //Int32.TryParse(PortToClose.Text, out int z);
            GetAvailablePort(443);

            if (443 > 0)
            {
                if (openedPort.Contains(443))
                {
                    GPN = "443";
                    //run netstat
                    try
                    {
                        String netStatArgs = "/C netstat -ao | find \"" + GPN + "\"";
                        Process netStatRun = new Process();
                        netStatRun.StartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            FileName = "cmd.exe",
                            Arguments = netStatArgs,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true
                        };
                        netStatRun.Start();
                        String NetstatOutput = netStatRun.StandardOutput.ReadToEnd();
                        netStatRun.WaitForExit(2000);
                        MessageBox.Show(NetstatOutput);
                        List<String> nsOut = NetstatOutput.Split('\n').ToList();
                        MessageBox.Show("\"" + nsOut.FirstOrDefault() + "\"");
                        String nsFirst = nsOut.FirstOrDefault();
                        List<String> nsOut2 = nsFirst.Split(' ').ToList();
                        ArrayList nsAL = new ArrayList();
                        for (int ns = 0; ns < nsOut2.Count; ns++)
                        {
                            nsAL.Add(nsOut2.ElementAt(ns));
                        }
                        //String toDis = "";
                        //foreach ( String dis in nsAL)
                        //{
                        //    toDis += "\n\""+dis+"\"";
                        //}
                        String getPosition6 = nsAL[6].ToString(); //the ip + port
                        String getPosition29 = nsAL[29].ToString(); //the pid

                        List<String> furtherSplit = getPosition6.Split(':').ToList();
                        getPosition6 = furtherSplit.ElementAt(1); // just port
                        if (getPosition6 != GPN)
                        {
                            MessageBox.Show("The port you are requesting to close is not open! ");
                        }
                        else if (getPosition6 == GPN)
                        {
                            
                            //netsh advfirewall firewall add rule name = \"Close Port getPosition6\" dir =in action = block protocol = TCP localport = getPostion6
                            String CPPArgs = "netsh advfirewall firewall add rule name = \"Close Port " + getPosition6 + "\" dir=in action=block protocol=TCP localport=" + getPosition6;
                            ProcessStartInfo closePortProc = new ProcessStartInfo
                            {
                                CreateNoWindow = true,
                                UseShellExecute = false,
                                FileName = "cmd.exe",
                                WindowStyle = ProcessWindowStyle.Normal,
                                Arguments = "/Ninjarku D Legend:A \"cmd /K " + CPPArgs + "\"",
                                RedirectStandardOutput = true,
                                Verb = "runas"
                            };
                            Process p1 = Process.Start(closePortProc);
                            String closePortProcOut = p1.StandardOutput.ReadToEnd();
                            p1.WaitForExit(2000);
                            MessageBox.Show("output: " + closePortProcOut + "\n" + "Port " + getPosition6 + " has been closed");

                            String KCPArgs = "/C taskkill /PID " + getPosition29 + " /F";
                            ProcessStartInfo KillcurrentProcess = new ProcessStartInfo
                            {
                                CreateNoWindow = false,
                                UseShellExecute = false,
                                FileName = "cmd.exe",
                                WindowStyle = ProcessWindowStyle.Normal,
                                Arguments = KCPArgs,
                                RedirectStandardOutput = true,
                                Verb = "runas"
                            };
                            Process p2 = Process.Start(KillcurrentProcess);
                            String killTaskOut = p2.StandardOutput.ReadToEnd();
                            p2.WaitForExit(2000);
                            MessageBox.Show("output: " + closePortProcOut + "\n" + "Taskkill done on process " + getPosition29);

                        }
                        else
                        {
                            MessageBox.Show("The port you are requesting to close is not open! ");
                        }
                        //MessageBox.Show(getPosition6+"\n"+getPosition29+"\n"+nsOut2.Count);
                    }
                    catch (Exception ve)
                    {
                        Console.WriteLine(ve.StackTrace);
                        MessageBox.Show("The port you are requesting to close is not open! ");
                    }
                }
                else
                {
                    MessageBox.Show("The value you entered is already closed!");
                }
            }
            else
            {
                MessageBox.Show("The port cannot be negative");
            }

            //image set
            int stat = -1;
            ImageSet(stat, CurrentOverallStatImg);
            LoadProgBar();
            //checks
            
            PortscanTrigger(2000);
            FirewallCheck();
            ProxyCheck();
           
            ICMPCheck();

        }

        private int storedStatPort = 0;
        private int storedStatProxy = 0;
        private int storedStatFirewall = 0;
        private int storedStatICMP = 0;
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
       //Arraylist for Open and Closed ports
        private static ArrayList closedPort = new ArrayList();
        private static ArrayList openedPort = new ArrayList();
        //Get Port Status UEV: User Enterable Value
        private void PortscanTrigger(int UEV)
        {
            //clear list first
            openedPort.Clear();
            closedPort.Clear();
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
            if (openedPort.Count >= 20)
            {
                this.storedStatPort = 1;
            }
            else if (openedPort.Count >= 10)
            {
                storedStatPort = 0;
            }
            else
            {
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

        private void FirewallCheck()
        {
            try
            {
                String FWCheckArgs = "/C netsh advfirewall show allprofiles";
                Process FWCheck = new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        FileName = "cmd.exe",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = FWCheckArgs,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    }
                };
                FWCheck.Start();
                String FWOutput = FWCheck.StandardOutput.ReadToEnd();

                FWCheck.WaitForExit(2000);
                //MessageBox.Show(FWOutput);

                List<String> FWOut = FWOutput.Split('\n').ToList();
                String FWString1 = FWOut.ElementAt(3);
                String FWString2 = FWOut.ElementAt(20);
                String FWString3 = FWOut.ElementAt(37);
                //MessageBox.Show("Check: " + FWString1);
                //MessageBox.Show("Check: " + FWString2);
                //MessageBox.Show("Check: " + FWString3);

                List<String> FWOut1 = FWString1.Split(' ').ToList();

                string text = File.ReadAllText("../../Resources\\Beck_Text/fw.txt");
                List<String> stext = text.Split('\n').ToList();
                String CompileVal = stext.ElementAt(3);

                //MessageBox.Show("Check: " + CompileVal);

                int counter = 0;
                if (FWString1.Equals(CompileVal))
                {
                    counter++;
                }

                if (FWString2.Equals(CompileVal))
                {
                    counter++;
                }

                if (FWString3.Equals(CompileVal))
                {
                    counter++;
                }

                if (counter == 3)
                {
                    storedStatFirewall = 1;
                }
                else if (counter == 2)
                {
                    storedStatFirewall = 0;
                }
                else
                {
                    storedStatFirewall = -1;
                }
            }
            catch (Exception s)
            {
                MessageBox.Show("Error: " + s.StackTrace);
            }
            
        }
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
        //Check for Web Proxy
        //private void CheckWebProxy()
        //{
        //    try
        //    {
        //        WebProxy proxy = (WebProxy)WebRequest.DefaultWebProxy;
        //        if (proxy.Address.AbsoluteUri != string.Empty)
        //        {
        //            Console.WriteLine("Proxy URL: " + proxy.Address.AbsoluteUri);
        //        }
        //        else
        //        {
        //            Console.WriteLine("No proxy url");
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
            IPStatus iPStatus = new IPStatus();
            if (iPStatus.ToString() == "Success")
            {
                //ICMP Echo is on: Not Ideal
                this.storedStatICMP = 0;
            }
            else
            {
                //ICMP Echo is off: Ideal
                this.storedStatICMP = 1;
            }
            ImageSet(this.storedStatICMP, ICMPEchoImg);
        }

        //Update on click settings
        //private void installupdatesyncwithinfo()
        //{
        //     updatecheckinfo info = null;

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

            /*Severity Check*/

        }
}
