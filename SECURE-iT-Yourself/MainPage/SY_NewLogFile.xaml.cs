using Microsoft.Win32;
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
    /// Interaction logic for SY_NewLogFile.xaml
    /// </summary>
    public partial class SY_NewLogFile : Window
    {
        private String c_name;
        private String filePath = "";


        public SY_NewLogFile(String c_name)
        {

            InitializeComponent();
            this.c_name = c_name;
            


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(c_name);
            wnd.Show();
            this.Close();


        }


        private void upload_button(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"c:\temp\";
            open.Title = "Select file to be upload";
            open.Filter = "Log Files (*.log)|*.log";

            try
            {

                if (open.ShowDialog() == true)
                {
                    if (open.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(open.FileName);
                        filePath = path;
                        ShowPath.Text = path;
                    }

                }
                else
                {
                    MessageBox.Show("Please upload document.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }

        private void validation_button(object sender, RoutedEventArgs e)
        {
            LogsDAO logdb = new LogsDAO();
            //Validation
            if (!(String.IsNullOrEmpty(Log_Name.Text)) && (logdb.checkIfLogs(Log_Name.Text)))
            {
                if (!(String.IsNullOrEmpty(Log_Desc.Text)))
                {
                    if (!(String.IsNullOrEmpty(filePath)))
                    {
                        if (formatBox.SelectedIndex > -1 && formatBox.SelectedIndex == 0)
                        {
                            CaseDAO casedb = new CaseDAO();
                            int caseId = casedb.getCaseId(c_name);
                            

                            Boolean checker = logdb.addLogToTable(Log_Name.Text, Log_Desc.Text, caseId, filePath, formatBox.Text);



                            if (checker) {

                                int logId = logdb.getLogId(Log_Name.Text);

                                SY_TagDAO tagdb = new SY_TagDAO();
                                tagdb.addTagToTable(Log_Name.Text, logId);

                                Console.WriteLine("WE DID IT!");
                                SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(c_name);
                                wnd.Show();
                                Close();
                            }



                        }
                        else
                        {
                            MessageBox.Show("Please select a file format");
                        }



                    }
                    else
                    {
                        MessageBox.Show("Please upload a path to load into");
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
