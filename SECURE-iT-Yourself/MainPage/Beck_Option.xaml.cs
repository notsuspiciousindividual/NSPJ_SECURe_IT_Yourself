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
            Scroller.Content = Beck_Content;

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

                PortCheckDP.Visibility = System.Windows.Visibility.Visible;
                PortCheckDP2.Visibility = System.Windows.Visibility.Visible;
                PortCheckDP3.Visibility = System.Windows.Visibility.Visible;
                PortOpenDP.Visibility = System.Windows.Visibility.Visible;
                PortCloseDP.Visibility = System.Windows.Visibility.Visible;
            }
            else if(lblMisconfigType.Content.Equals("Proxy Server on/off"))
            {
                MessageBox.Show("Something else");
            }
        }
        //Check Port
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            //ReturnActCheck
            if (ReturnActCheck2.IsVisible || ReturnActCheck3.IsVisible)
            {
                ReturnActCheck2.Visibility = System.Windows.Visibility.Collapsed;
                ReturnActCheck3.Visibility = System.Windows.Visibility.Collapsed;
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
            for (int r = 1; r < 50000; r++)
            {
                GetAvailablePort(r);
            }
           //get port number first
           String GPN = "";
           Int32.TryParse(PortToClose.Text, out int z);

            if (z > 0)
            {
                if (openedPort.Contains(z))
                {
                    GPN = PortToClose.Text;
                    String ArgsIn = "advfirewall firewall delete rule name =\"Close Port " + GPN + "\" dir=in action=block protocol=TCP localport=" + GPN;
                    ProcessStartInfo addRule = new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "netsh",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = ArgsIn,
                        RedirectStandardOutput = true
                    };
                    addRule.Verb = "runas";
                    Process proc = Process.Start(addRule);

                    try
                    {
                        StreamReader ProxyOutput = proc.StandardOutput;
                        proc.WaitForExit(2000);
                        string output = "";
                        //MessageBox.Show("stream read success");

                        if (proc.HasExited)
                        {
                            output = ProxyOutput.ReadToEnd();
                            //MessageBox.Show("process output update sucess");

                        }
                        ProxyOutput.Close();
                        MessageBox.Show(output);
                    }
                    catch (Exception pe)
                    {
                        MessageBox.Show("Error: " + pe.Message);
                    }
                    //run netstat
                    String netStatArgs = "-ano | find /"443/"";
                    ProcessStartInfo netstatRun = new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = false,
                        FileName = "netstat",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        Arguments = ArgsIn,
                        RedirectStandardOutput = true
                    };
                    //get values from netstat
                    //split it up
                    //
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
                String ArgsIn = "advfirewall firewall add rule name =\"Open Port " + GPN + "\" dir=in action=allow protocol=TCP localport=" + GPN;

                ProcessStartInfo addRule = new ProcessStartInfo
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    FileName = "netsh",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = ArgsIn,
                    RedirectStandardOutput = true
                };
                addRule.Verb = "runas";
                Process proc = Process.Start(addRule);

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

        //Check 
    }
 }
