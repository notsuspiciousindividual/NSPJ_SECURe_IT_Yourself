using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            
            //Add in the Title
            String OptionTitle = "Firewall Settings";
            lblMisconfigType.Content = OptionTitle;
            //Add in the Image
           // Image setImage = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("//Resource//Beck_Images//Background.jpg", UriKind.Absolute);
            //setImage.Source = src;
            StatusImage.Source = src;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
 }
