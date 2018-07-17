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
            this.c_name = c_name;
            this.c_desc = c_desc;
            this.investList = investList;

            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SY_NewCase wnd = new SY_NewCase();
            wnd.Show();
            this.Close();


        }


        private void upload_button(object sender, RoutedEventArgs e)
        {
            


        }

        private void validation_button(object sender, RoutedEventArgs e) {


        }


    }
}
