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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainPage
{
    /// <summary>
    /// Interaction logic for SY_NetworkStart.xaml
    /// </summary>
    public partial class SY_NetworkStart : Window
    {
        public SY_NetworkStart()
        {
            InitializeComponent();
        }


        private void New_Case_Network(object sender, RoutedEventArgs e)
        {

            SY_NewCase wnd = new SY_NewCase();
            wnd.Show();
            this.Close();
        }
    }
}
