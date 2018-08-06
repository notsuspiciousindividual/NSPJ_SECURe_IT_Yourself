using Microsoft.Win32;
using System;
using System.Collections;
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
    /// Interaction logic for SY_NetworkLogUpload.xaml
    /// </summary>
    public partial class SY_NetworkLogUpload : Window
    {
        private String c_name;
        private String c_desc;
        private ArrayList investList;
        private String filePath = "";
       


        public SY_NetworkLogUpload(String c_name, String c_desc, ArrayList investList)
        {

            InitializeComponent();

            this.c_name = c_name;
            this.c_desc = c_desc;
            this.investList = investList;

            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SY_NewCase wnd = new SY_NewCase();
            wnd.Show();
            this.Close();


        }


        private void upload_button(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"c:\temp\";
            open.Title = "Select file to be upload";
            open.Filter = "Log Files (*.log)|*.log|Pcap Files (*.pcap)|*.pcap";
           
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);

            }


        }

        private void validation_button(object sender, RoutedEventArgs e) {
            //Validation
            if (!(String.IsNullOrEmpty(Log_Name.Text)))
            {
                if (!(String.IsNullOrEmpty(Log_Desc.Text)))
                {
                    if (!(String.IsNullOrEmpty(filePath)))
                    {
                        if (formatBox.SelectedIndex > -1)
                        {
                            LogsDAO logDb = new LogsDAO();

                            if (logDb.checkIfLogs(Log_Name.Text))
                            {
                                CaseDAO db = new CaseDAO();

                                SY_TagDAO tagdb = new SY_TagDAO();

                                Boolean checker = db.addCaseToTable(c_name, c_desc, investList);

                                Boolean checker2 = false;

                                Boolean checker3 = false;

                                

                                if (checker)
                                {
                                    int caseId = db.getCaseId(c_name);
                                    checker2 = logDb.addLogToTable(Log_Name.Text, Log_Desc.Text, caseId, filePath, formatBox.Text);
                                    
                                }
                                


                                if (checker2)
                                {

                                    int logId = logDb.getLogId(Log_Name.Text);
                                    checker3 = tagdb.addTagToTable(Log_Name.Text, logId);

                                    Console.WriteLine("WE DID IT!");
                                    
                                    
                                    SY_CreatedSuccessCase wnd = new SY_CreatedSuccessCase();
                                    wnd.Show();
                                    Close();

                                }
                                else
                                {
                                    Console.WriteLine("Its not there");
                                }
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
