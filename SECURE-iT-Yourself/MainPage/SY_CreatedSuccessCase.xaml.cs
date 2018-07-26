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
    /// Interaction logic for SY_CreatedSuccessCase.xaml
    /// </summary>
    public partial class SY_CreatedSuccessCase : Window
    {
        public SY_CreatedSuccessCase()
        {
            InitializeComponent();
        }

        private void ToHome(object sender, RoutedEventArgs e)
        {
            
        }

        private void ToForensics(object sender, RoutedEventArgs e)
        {
            SY_NetworkStart wnd = new SY_NetworkStart();

            wnd.Show();

            this.Close();
        }
    }
}
