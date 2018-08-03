using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Beck_Pass.xaml
    /// </summary>
    public partial class Beck_Pass : Window
    {
        public Beck_Pass()
        {
            InitializeComponent();
        }

        //Variables
        String PID = ""; //process ID 
        String GPN = ""; // Get Port Number
        public void PassIn(String PID, String GPN)
        {
            this.PID = PID;
            this.GPN = GPN;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            //need GPN, netstat values of port and PID a
            String UserI = UsernameInput.Text;
            String PassI = PasswordInput.Password;
            System.Windows.Forms.MessageBox.Show("Username: "+UserI+"\nPassword: "+PassI);

            try
            {
                int x = 1;
                if (x == 1)
                {
                    System.Windows.Forms.MessageBox.Show("GPN: "+GPN+"\nPID: "+PID);
                    String CPPArgs = "/C netsh advfirewall firewall add rule name = \"Close Port " + GPN + "\" dir=in action=block protocol=TCP localport=" + GPN;
                    ProcessStartInfo closePortProc = new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        UseShellExecute = true,
                        FileName = "cmd.exe",
                        WindowStyle = ProcessWindowStyle.Hidden,
                        //Arguments = "/"+UserI+":"+PassI+" \"cmd /K " + CPPArgs + "\"",
                        //Arguments = "/User:Administrator \"cmd /K "+CPPArgs+"\"",
                        Arguments = CPPArgs,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Verb = "runas"
                    };
                    Process p1 = Process.Start(closePortProc);
                    String closePortProcOut = p1.StandardOutput.ReadToEnd();
                    p1.WaitForExit(2000);
                    MessageBox.Show("output: " + closePortProcOut + "\n" + "Port " + GPN + " has been closed");

                    String KCPArgs = "/C taskkill /PID " + PID + " /F";
                    ProcessStartInfo KillcurrentProcess = new ProcessStartInfo
                    {
                        CreateNoWindow = false,
                        UseShellExecute = true,
                        FileName = "cmd.exe",
                        WindowStyle = ProcessWindowStyle.Normal,
                        Arguments = "/" + UserI + ":" + PassI + " \"cmd /K " + KCPArgs + "\"",
                        RedirectStandardOutput = true,
                        Verb = "runas"
                    };
                    Process p2 = Process.Start(KillcurrentProcess);
                    String killTaskOut = p2.StandardOutput.ReadToEnd();
                    p2.WaitForExit(2000);
                    MessageBox.Show("output: " + closePortProcOut + "\n" + "Taskkill done on process " + PID);
                }
            }
            catch (Exception ef)
            {
                System.Windows.Forms.MessageBox.Show("Error: "+ef.StackTrace);
            }
           
        }
        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {

        }
        

    }
}
