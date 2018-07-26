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
    /// Interaction logic for SY_ViewSpecificCase.xaml
    /// </summary>
    public partial class SY_ViewSpecificCase : Window
    {

        private String C_Name="";

        public SY_ViewSpecificCase(String C_Name)
        {
            this.C_Name = C_Name;
            InitializeComponent();
            this.Case_Label.Content = C_Name;
        }
    }
}
