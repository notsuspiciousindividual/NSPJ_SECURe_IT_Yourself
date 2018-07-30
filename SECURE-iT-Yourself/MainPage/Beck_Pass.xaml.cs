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
    /// Interaction logic for Beck_Pass.xaml
    /// </summary>
    public partial class Beck_Pass : Window
    {
        public Beck_Pass()
        {
            InitializeComponent();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            String UserI = UsernameInput.Text;
            String PassI = PasswordInput.Password;
            System.Windows.Forms.MessageBox.Show("Username: "+UserI+"\nPassword: "+PassI);
        }
        private void Cancel_Click_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
