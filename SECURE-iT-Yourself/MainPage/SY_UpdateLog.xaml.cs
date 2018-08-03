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

namespace MainPage
{
    /// <summary>
    /// Interaction logic for SY_UpdateLog.xaml
    /// </summary>
    public partial class SY_UpdateLog : Window
    {
        private String caseName;
        private String oldName;



        public SY_UpdateLog(String logName, String logDesc, String Case_Name)
        {
            InitializeComponent();
            Log_Name.Text = logName;
            Log_Desc.Text = logDesc;
            caseName = Case_Name;
            oldName = Case_Name;
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(caseName);
            wnd.Show();
            Close();


        }



        private void validation_button(object sender, RoutedEventArgs e)
        {
            LogsDAO logdb = new LogsDAO();
            //Validation
            if ( (Log_Name.Text.Equals(oldName)) || (logdb.checkIfLogs(Log_Name.Text)) || !(String.IsNullOrEmpty(Log_Name.Text)) )
            {
                if (!(String.IsNullOrEmpty(Log_Desc.Text)))
                {
                   
                    Boolean checker = logdb.UpdateToTable(Log_Name.Text, Log_Desc.Text, oldName);
                    if (checker)
                    {
                        SY_TagDAO tagdb = new SY_TagDAO();

                        tagdb.UpdateLogName(Log_Name.Text, oldName);

                        Console.WriteLine("WE DID IT!");
                        SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(caseName);
                        wnd.Show();
                        Close();

                    }
                }
                else
                {
                    MessageBox.Show("Please fill up the Log Description");
                }
            }
            else
            {
                MessageBox.Show("Please fill up in the Log Name");
            }

        }
    }
}
