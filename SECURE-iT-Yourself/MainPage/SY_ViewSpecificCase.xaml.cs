using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            Case_Label.Content = C_Name;
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;

            string query = "SELECT Log_Name, Log_Desc FROM Network_Log";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
            {
                DataTable table = new DataTable("Network_Log");
                adapt.Fill(table);
                LogTable.ItemsSource = table.DefaultView;
            }
        }


        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_ViewCases wnd = new SY_ViewCases();
            wnd.Show();
            this.Close();

        }

        private void View_Log(object sender, RoutedEventArgs e) {
            var button = sender as DependencyObject;

            while ((button != null) && !(button is DataGridRow))
            {
                button = VisualTreeHelper.GetParent(button);
            }

            if (button is DataGridRow)
            {
                Console.WriteLine("YESH");
                DataGridRow cell = button as DataGridRow;
                TextBlock potatoe = LogTable.Columns[0].GetCellContent(cell) as TextBlock;

                SY_ViewSpecificTeam wnd = new SY_ViewSpecificTeam(potatoe.Text);
                wnd.Show();
                Close();
            }

        }

    }
}
