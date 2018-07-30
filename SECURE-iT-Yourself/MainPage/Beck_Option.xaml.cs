using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
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

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Beck_Option.xaml
    /// </summary>
    public partial class Beck_Option : Window
    {
        public Beck_Option()
        {
            InitializeComponent();

        }
        public void ImageSet(int Status, Image img)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Beck_NC wnd = new Beck_NC();
            wnd.Show();

            this.Close();
        }
        //To pull the data from previous window 
        public void Transfer(String pageName, int statNo)
        {
            MessageBox.Show("Stat No: " + statNo + "\nPage Name:" + pageName);
            //Add in the Title
            String OptionTitle = pageName;
            lblMisconfigType.Content = OptionTitle;
            //Add in the Image
            ImageSet(statNo, StatusImage);
            ContentToLoad();
        }
        //some vars
        private static ArrayList openedPort = new ArrayList();
        private static ArrayList closedPort = new ArrayList();
//*************************************************************************************************************************************************//
        public void ContentToLoad() 
        {
            if (lblMisconfigType.Content.Equals("Check on Ports"))
            {

                //first row
                //DockPanel PortCheckDP = new DockPanel
                //{
                //    Name = "PortCheckDP"
                //};
                //Label lblTextPort = new Label
                //{
                //    Content = "Scan from port 1 ~ "
                //};
                //Thickness marginlbl1 = lblTextPort.Margin;
                //marginlbl1.Left = 20;
                //lblTextPort.Margin = marginlbl1;
                //TextBox PortSpecific = new TextBox
                //{
                //    Text = "",
                //    Width = 60,
                //    Name = "SpecificPortRange",
                //    IsReadOnly = false,
                //    VerticalAlignment = VerticalAlignment.Center,
                //    MaxLength = 5
                //};
                //Thickness margin1 = PortSpecific.Margin;
                //margin1.Right = 10;
                //PortSpecific.Margin = margin1;
                //this.PortSpecificText = PortSpecific.Text;

                //Button btnActivate = new Button
                //{
                //    Content = "Check",
                //    Name = "ActivateCheck"
                //};
                //btnActivate.Click += new RoutedEventHandler(Check_Click);
                //Thickness marginbtn1 = btnActivate.Margin;
                //marginbtn1.Right = 20;
                //btnActivate.Margin = marginbtn1;

                //PortCheckDP.Children.Add(lblTextPort);
                //PortCheckDP.Children.Add(PortSpecific);
                //PortCheckDP.Children.Add(btnActivate);

                //second row
                //DockPanel PortCheckDP2 = new DockPanel();

                //Label lblTextPort2 = new Label
                //{
                //    Content = "Scan Specific port: "
                //};
                //Thickness marginlbl2 = lblTextPort2.Margin;
                //marginlbl2.Left = 20;
                //lblTextPort2.Margin = marginlbl2;

                //TextBox PortSpecific2 = new TextBox
                //{
                //    Text = "",
                //    Width = 60,
                //    IsReadOnly = false,
                //    VerticalAlignment = VerticalAlignment.Center,
                //    MaxLength = 5
                //};
                //Thickness margin2 = PortSpecific2.Margin;
                //margin2.Right = 14; 
                //PortSpecific2.Margin = margin2;

                //Button btnActivate2 = new Button
                //{
                //    Content = "Check",
                //    Name = "ActivateCheck"
                //};
                //btnActivate2.Click += new RoutedEventHandler(Check_Click2);
                //Thickness marginbtn2 = btnActivate2.Margin;
                //marginbtn2.Right = 20;
                //btnActivate2.Margin = marginbtn2;

                //PortCheckDP2.Children.Add(lblTextPort2);
                //PortCheckDP2.Children.Add(PortSpecific2);
                //PortCheckDP2.Children.Add(btnActivate2);

                //add in to the stack panel
                //Beck_Content.Children.Add(PortCheckDP);
                //Beck_Content.Children.Add(PortCheckDP2);

                PortCheckDP.Visibility = Visibility.Visible;
                PortCheckDP2.Visibility = Visibility.Visible;
                PortCheckDP3.Visibility = Visibility.Visible;
                PortOpenDP.Visibility = Visibility.Visible;
                PortCloseDP.Visibility = Visibility.Visible;
            }
            else if (lblMisconfigType.Content.Equals("Proxy Server on/off"))
            {
                ProxyCheckDisplay();
                ProxyDP.Visibility = Visibility.Visible;
            }
            else if (lblMisconfigType.Content.Equals("Firewall on/off"))
            {
                Firewall_CheckSet();
                FirewallDP.Visibility = Visibility.Visible;
                FirewallStat.Visibility = Visibility.Visible;
            }
            else if (lblMisconfigType.Content.Equals("ICMP on/off"))
            {
                ICMPCheckSet();
                DisplayIPInfo.Visibility = Visibility.Visible;
                ICMPDP.Visibility = Visibility.Visible;
            }
            else if (lblMisconfigType.Content.Equals("Updates"))
            {

            }
            else if (lblMisconfigType.Content.Equals("Configuration Severity"))
            {

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You typed the name wrongly!");
            }
        }
        //Check Port
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            //ReturnActCheck
            if (ReturnActCheck2.IsVisible || ReturnActCheck3.IsVisible)
            {
                ReturnActCheck2.Visibility = Visibility.Collapsed;
                ReturnActCheck3.Visibility = Visibility.Collapsed;
            }
            Int32.TryParse(SpecificPortRange.Text, out int x);
            if (x != 0)
            {
                openedPort.Clear();
                closedPort.Clear();
                for(int runL = 1; runL<=x; runL++)
                {
                    GetAvailablePort(runL);
                }
                //PortCheckDP.children.add();
                //DockPanel openDP = new DockPanel();

                //String Closed = "";
                //for (int l = 0; l<closedPort.Count; l++)
                //{
                //    Closed += closedPort[l] + " ";
                //}
                String Opened = "";
                for (int d = 0; d < openedPort.Count; d++)
                {
                    Opened += openedPort[d] + " ";
                }
                ReturnActCheck.Text = "(Note, the larger your range, the longer the time taken to check)" + "\nOpened Ports: \n" + Opened /*+ "\nClosed Ports: \n" + Closed*/;
                ReturnActCheck.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                MessageBox.Show("The Value you have entered is not an integer!");
            }
        }
        private void Check_Click2(object sender, RoutedEventArgs e)
        {
            //ReturnActCheck2
            if (ReturnActCheck.IsVisible || ReturnActCheck3.IsVisible)
            {
                ReturnActCheck.Visibility = System.Windows.Visibility.Collapsed;
                ReturnActCheck3.Visibility = System.Windows.Visibility.Collapsed;
            }
            Int32.TryParse(SpecificPort.Text, out int x);
            closedPort.Clear();
            openedPort.Clear();
            GetAvailablePort(x);
            if (openedPort.Count > 0)
            {
                ReturnActCheck2.Text = "Port "+openedPort[0]+" is opened";
            }
            else if (closedPort.Count > 0)
            {
                ReturnActCheck2.Text = "Port " + closedPort[0] + " is closed";
            }
            else
            {
                MessageBox.Show("The value you have entered is not an integer!");
            }
            ReturnActCheck2.Visibility = System.Windows.Visibility.Visible;

        }
        private void Check_Click3(object sender, RoutedEventArgs e)
        {
            //ReturnActCheck3
            if (ReturnActCheck.IsVisible || ReturnActCheck2.IsVisible)
            {
                ReturnActCheck.Visibility = System.Windows.Visibility.Collapsed;
                ReturnActCheck2.Visibility = System.Windows.Visibility.Collapsed;
            }
            Int32.TryParse(PortStart.Text, out int x);
            Int32.TryParse(PortEnd.Text, out int y); 

            if (x < y)
            {
                closedPort.Clear();
                openedPort.Clear();
                for (int i = x; i <= y; i++)
                {
                    GetAvailablePort(i);
                }
                if (openedPort.Count > 0)
                {
                    String portOpenVal = "";
                    for (int loop = 0; loop < openedPort.Count; loop++)
                    {
                        portOpenVal += " " + openedPort[loop];
                    }
                    ReturnActCheck3.Text = "Port(s) opened:\n" + portOpenVal
                        ;
                    ReturnActCheck3.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    ReturnActCheck3.Text = "There are no ports opened in within the range you have specified";
                    ReturnActCheck3.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (y > x)
            {
                closedPort.Clear();
                openedPort.Clear();
                for (int i = y; i <= x; i++)
                {
                    GetAvailablePort(i);
                }
                if (openedPort.Count > 0)
                {
                    String portOpenVal = "";
                    for (int loop = 0; loop < openedPort.Count; loop++)
                    {
                        portOpenVal += " " + openedPort[loop];
                    }
                    ReturnActCheck3.Text = "Port(s) opened:\n" + portOpenVal
                        ;
                    ReturnActCheck3.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    ReturnActCheck3.Text = "There are no ports opened in within the range you have specified";
                    ReturnActCheck3.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else if (x <= 0 || y <= 0)
            {
                MessageBox.Show("Your ports cannot be negative!");
            }
            else
            {
                MessageBox.Show("The value you have entered is not an integer!");
            }

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
        private void ClosePortRule_Click(object sender, RoutedEventArgs e)
        {
            //get the open ports first
            openedPort.Clear();
            closedPort.Clear();
            
           //get port number first
            String GPN = "";
            Int32.TryParse(PortToClose.Text, out int z);
            GetAvailablePort(z);

            if (z > 0)
            {
                if (openedPort.Contains(z))
                {
                    GPN = PortToClose.Text;
                    //run netstat
                    try
                    {
                        String netStatArgs = "/C netstat -ao | find \""+GPN+"\"";
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
                            String CPPArgs = "/C netsh advfirewall firewall add rule name = \"Close Port " + getPosition6 + "\" dir=in action=block protocol=TCP localport=" + getPosition6;
                            ProcessStartInfo closePortProc = new ProcessStartInfo
                            {
                                CreateNoWindow = false,
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
                            MessageBox.Show("output: "+closePortProcOut+"\n"+"Port " + getPosition6 + " has been closed");

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
        }
        private void OpenPortRule_Click(object sender, RoutedEventArgs e)
        {
            //get port number first
            String GPN = "";
            Int32.TryParse(PortToOpen.Text, out int z);

            if (z > 0)
            {
                GPN = PortToOpen.Text;
                String ArgsIn = "advfirewall firewall delete rule name =\"Close Port " + GPN + "\" protocol=TCP localport=" + GPN;

                ProcessStartInfo reOpenPort = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = "netsh",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = ArgsIn,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                Process proc = Process.Start(reOpenPort);

                try
                {
                    StreamReader ProxyOutput = proc.StandardOutput;
                    proc.WaitForExit(2000);
                    string output = "";
                    MessageBox.Show("stream read success");

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
            }
        }

        //Check Proxy
        private void ProxyCheckDisplay()
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
                ProxyTxt.Text = output;
                string text = File.ReadAllText("../../Resources\\Beck_Text/proxy.txt");
                //MessageBox.Show("\""+output+"\"");
                int stat;
                if (output.Equals(text))
                {
                    //MessageBox.Show("No web proxy");
                    stat = 0;
                }
                else
                {
                    stat = 1;
                }
                ImageSet(stat, StatusImage);
                System.Windows.Forms.MessageBox.Show("output "+output);
                ProxyTxt.Text = output;

            }
            catch (Exception pe)
            {
                MessageBox.Show("Error: " + pe.Message);
            }
        }
        //Check Firewall
        private void Firewall_CheckSet()
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
                MessageBox.Show(FWOutput);

                List<String> FWOut = FWOutput.Split('\n').ToList();
                String FWString1 = FWOut.ElementAt(3);
                String FWString2 = FWOut.ElementAt(20);
                String FWString3 = FWOut.ElementAt(37);
                MessageBox.Show("Check: " + FWString1);
                List<String> FWOut1 = FWString1.Split(' ').ToList();

                string text = File.ReadAllText("../../Resources\\Beck_Text/fw.txt");
                List<String> stext = text.Split('\n').ToList();
                String CompileVal = stext.ElementAt(3);

                int counter = 0;
                if (FWString1.Equals(CompileVal))
                {
                    //MessageBox.Show("Try 1: "+FWString1); 
                    counter++;
                }

                if (FWString2.Equals(CompileVal))
                {
                    //MessageBox.Show("Try 2: " + FWString2);
                    counter++;
                }

                if (FWString3.Equals(CompileVal))
                {
                    //MessageBox.Show("Try 3: " + FWString3);
                    counter++;
                }

                if (counter == 3)
                {
                    FWOnOffCombo.SelectedIndex = 0;
                }
                else
                {
                    FWOnOffCombo.SelectedIndex = 1;
                }
                FirewallStat.Text = FWOutput;
            }
            catch (Exception s)
            {
                MessageBox.Show("Error: " + s.StackTrace);
            }
            
        }
        private void FWApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            String comboSelected = FWOnOffCombo.SelectionBoxItem.ToString();
            if (comboSelected == "On")
            {
                String OnArg = "/C netsh advfirewall set allprofiles state off";
                ProcessStartInfo FirewallChange = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Maximized,
                    Arguments = OnArg,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                MessageBox.Show("Process Ran");
                Process ChangeRun = Process.Start(FirewallChange);

                ImageSet(1, StatusImage);
            }
            else if (comboSelected == "Off")
            {
                String OffArg = "/C netsh advfirewall set allprofiles state on";
                ProcessStartInfo FirewallChange = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Maximized,
                    Arguments = OffArg,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                MessageBox.Show("Process Ran");
                Process ChangeRun = Process.Start(FirewallChange);

                ImageSet(-1, StatusImage);

            }
        }
        //Check ICMP 
        private void ICMPCheckSet()
        {
            String Printable = "";
            String strHostName = "";
            // Get the host name of local machine.
            strHostName = Dns.GetHostName();
            Printable += "\nLocal Machine's Host Name: " + strHostName;

            // Use host name, get the IP address list
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            String IPAdd = addr[addr.Length - 1].ToString();

            Printable += "\nIP Address: " + IPAdd;
            //ICMP checking portion
            IPStatus iPStatus = new IPStatus();
            Printable += "\nIP status: " + iPStatus;
            int stat = 0;
            if (iPStatus.ToString() == "Success")
            {
                //Not Ideal
                Printable += "\nICMP Echo is on";
                stat = 0;
            }
            else
            {
                //Ideal
                Printable += "\nICMP Echo is off";
                stat = 1;
            }
            ICMPOnOffCombo.SelectedIndex = stat;
            DisplayIPInfo.Text = Printable;

            //ICMPOn.IsChecked = true;
            //ICMPOff.IsChecked = false;
        }
        private void ICMPEditApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            String ICMPVal = ICMPOnOffCombo.SelectionBoxItem.ToString();
            MessageBox.Show(ICMPVal);
            if (ICMPVal.Equals("On"))
            {
                String ICMPChangeArgs = "";
                ProcessStartInfo ICMPChange = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = "cmd.exe",
                    WindowStyle = ProcessWindowStyle.Maximized,
                    Arguments = ICMPChangeArgs,
                    RedirectStandardOutput = true,
                    Verb = "runas"
                };
                MessageBox.Show("Process Ran");
                Process ChangeRun = Process.Start(ICMPChange);

            }
            //else if(ICMPVal.Equals("Off"))
            //{

            //}
            else
            {

            }
        }
    }
 }
