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
               
            //To pull the data from previous window 

            //Add in the Title
            String OptionTitle = "Firewall Settings";
            lblMisconfigType.Content = OptionTitle;
            //Add in the Image

            int stat = 1;
            ImageSet(stat, StatusImage);

        }
        public void ImageSet(int Status, Image img)
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Beck_NC wnd = new Beck_NC();
            wnd.Show();

            this.Close();
        }
    }
 }
