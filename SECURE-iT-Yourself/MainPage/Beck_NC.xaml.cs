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
            //setting overall status Image
             int stat = -1;
            ImageSet(stat, CurrentOverallStatImg);

        }
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
        private async void startupProg()
        {
            //init data
            List<String> list = new List<String>();
            //for (int i = 0 ;)
            
        }

        private void Initials()
        {
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

            //Check for ports that are open
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
        // Update on click settings
        //private void InstallUpdateSyncWithInfo()
        //{
        //    UpdateCheckInfo info = null;

        //    if (ApplicationDeployment.IsNetworkDeployed)
        //    {
        //        ApplicationDeployment ad = ApplicationDeployment.CurrentDeployment;

        //        try
        //        {
        //            info = ad.CheckForDetailedUpdate();

        //        }
        //        catch (DeploymentDownloadException dde)
        //        {
        //            MessageBox.Show("The new version of the application cannot be downloaded at this time. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
        //            return;
        //        }
        //        catch (InvalidDeploymentException ide)
        //        {
        //            MessageBox.Show("Cannot check for a new version of the application. The ClickOnce deployment is corrupt. Please redeploy the application and try again. Error: " + ide.Message);
        //            return;
        //        }
        //        catch (InvalidOperationException ioe)
        //        {
        //            MessageBox.Show("This application cannot be updated. It is likely not a ClickOnce application. Error: " + ioe.Message);
        //            return;
        //        }

        //        if (info.UpdateAvailable)
        //        {
        //            Boolean doUpdate = true;

        //            if (!info.IsUpdateRequired)
        //            {
        //                DialogResult dr = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel);
        //                if (!(DialogResult.OK == dr))
        //                {
        //                    doUpdate = false;
        //                }
        //            }
        //            else
        //            {
        //                // Display a message that the app MUST reboot. Display the minimum required version.
        //                MessageBox.Show("This application has detected a mandatory update from your current " +
        //                    "version to version " + info.MinimumRequiredVersion.ToString() +
        //                    ". The application will now install the update and restart.",
        //                    "Update Available", MessageBoxButtons.OK,
        //                    MessageBoxIcon.Information);
        //            }

        //            if (doUpdate)
        //            {
        //                try
        //                {
        //                    ad.Update();
        //                    MessageBox.Show("The application has been upgraded, and will now restart.");
        //                    Application.Restart();
        //                }
        //                catch (DeploymentDownloadException dde)
        //                {
        //                    MessageBox.Show("Cannot install the latest version of the application. \n\nPlease check your network connection, or try again later. Error: " + dde);
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //} 
        //Type Ctrl K C

        //protected override void (EventArgs e)
        //{
        //    base.OnLoad(e);
        //    UpdateSession uSession = new UpdateSession();
        //    IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
        //    uSearcher.Online = false;
        //    try
        //    {
        //        ISearchResult sResult = uSearcher.Search("IsInstalled=1 And IsHidden=0");
        //        textBox1.Text = "Found " + sResult.Updates.Count + " updates" + Environment.NewLine;
        //        foreach (IUpdate update in sResult.Updates)
        //        {
        //            textBox1.AppendText(update.Title + Environment.NewLine);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Something went wrong: " + ex.Message);
        //    }
        //}
    }
}
