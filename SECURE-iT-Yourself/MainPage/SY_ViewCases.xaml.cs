using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainPage
{
    /// <summary>
    /// Interaction logic for SY_ViewCases.xaml
    /// </summary>
    public partial class SY_ViewCases : Window
    {
        public SY_ViewCases()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_NetworkStart wnd = new SY_NetworkStart();
            wnd.Show();
            this.Close();


        }

        private void FillDataGrid() {
            string connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;

            string query = "SELECT C_Name, C_Description FROM Cases";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable("Cases");
                adapt.Fill(table);
                CaseTable.ItemsSource = table.DefaultView;
            }

            Button btn = new Button();
        }

        private void View_Case(object sender, RoutedEventArgs e)
        {
            var button = sender as DependencyObject;

            while ((button != null) && !(button is DataGridRow)) {
                button = VisualTreeHelper.GetParent(button);
            }

            if (button is DataGridRow)
            {
                Console.WriteLine("YESH");
                DataGridRow cell = button as DataGridRow;
                
                
                TextBlock potatoe = CaseTable.Columns[0].GetCellContent(cell) as TextBlock;

                SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(potatoe.Text);
                wnd.Show();
                this.Close();

                
                
                

               

            }
            


        }

        //private void DataGridTemplateColumn_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    DependencyObject dep = (DependencyObject)e.OriginalSource;

        //    while ((dep != null))
        //    {
        //        dep = VisualTreeHelper.GetParent(dep);



        //    }




        //    if (dep is DataGridCell)
        //    {
        //        Console.WriteLine("DEEZ NUTS AHAH");

        //    }
        //    else {
        //        Console.WriteLine("No detect, ahhh");

        //    }

        //}
    }
}
