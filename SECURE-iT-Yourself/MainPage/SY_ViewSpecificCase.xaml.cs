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

            CaseDAO caseDb = new CaseDAO();
            int case_id = caseDb.getCaseId(C_Name);

            string query = "SELECT Log_Name, Log_Desc FROM Network_Log WHERE Case_Id = @cId";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@cId", case_id);

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

                SY_ViewSpecificTeam wnd = new SY_ViewSpecificTeam(potatoe.Text, C_Name);
                wnd.Show();
                Close();
            }

        }

        private void Remove_Item(object sender, RoutedEventArgs e)
        {
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
                LogsDAO logsdb = new LogsDAO();
                Boolean checker = logsdb.deleteLogFromTable(potatoe.Text);

                if (checker)
                {
                    SY_TagDAO tagdb = new SY_TagDAO();
                    tagdb.deleteTagFile(potatoe.Text);

                    Console.WriteLine("It works!");
                    FillDataGrid();
                }
                else
                {
                    Console.WriteLine("It does not work");
                }


            }

        }

        private void Edit_Item(object sender, RoutedEventArgs e)
        {
            var button = sender as DependencyObject;

            while ((button != null) && !(button is DataGridRow))
            {
                button = VisualTreeHelper.GetParent(button);
            }

            if(button is DataGridRow)
            {
                Console.WriteLine("YO!");
                DataGridRow cell = button as DataGridRow;
                TextBlock potatoe = LogTable.Columns[0].GetCellContent(cell) as TextBlock;
                TextBlock potatoe2 = LogTable.Columns[1].GetCellContent(cell) as TextBlock;
                String caseName = C_Name;

                SY_UpdateLog wnd = new SY_UpdateLog(potatoe.Text, potatoe2.Text, caseName);
                wnd.Show();
                Close();


            }
        }

        private void Upload_Log(object sender, RoutedEventArgs e)
        {
            SY_NewLogFile wnd = new SY_NewLogFile(C_Name);
            wnd.Show();
            Close();

        }
    }
}
