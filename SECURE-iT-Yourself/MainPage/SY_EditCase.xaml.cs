using Newtonsoft.Json;
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
    /// Interaction logic for SY_EditCase.xaml
    /// </summary>
    public partial class SY_EditCase : Window
    {
        private String cName = "";
        private String OldCase = "";
        private String path = " ";

        public SY_EditCase(String caseName)
        {

            this.cName = caseName;
            InitializeComponent();
            LoadData();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_ViewCases wnd = new SY_ViewCases();
            wnd.Show();
            this.Close();

        }

        private void LoadData() {
            CaseDAO casedb = new CaseDAO();
            Case data = casedb.getCaseFromTable(cName);
            case_name.Text = data.C_Name;
            case_desc.Text = data.C_Desc;
            List<String> items = data.C_Authors.ToList();

            foreach (var item in items)
            {
                investList.Items.Add(item);
            }

            OldCase = case_name.Text;
            path = data.pathAuthors;

        }

        private void Verify_Next(object sender, RoutedEventArgs e)
        {

            //Validation
            if (!(String.IsNullOrEmpty(case_name.Text)))
            {
                if (!(String.IsNullOrEmpty(case_desc.Text)))
                {
                    if (!(investList.Items.Count == 0))
                    {
                        CaseDAO db = new CaseDAO();


                        //Push to next page and ask for network file
                        String CName = case_name.Text;
                        String CDesc = case_desc.Text;
                        if ((CName.Equals(OldCase)) || (db.checkIfCaseName(CName)))
                        {
                            List<String> aList = new List<String>();
                            for (int i = 0; i < investList.Items.Count; i++)
                            {
                                ListBoxItem item = (ListBoxItem)(investList.ItemContainerGenerator.ContainerFromIndex(i));
                                aList.Add(item.Content.ToString());
                            }

                            Case newCase = new Case(CName, CDesc, path);

                            CaseDAO casedb = new CaseDAO();
                            Boolean checker = casedb.updateToTable(newCase, OldCase);
                            if (checker)
                            {
                                string json = JsonConvert.SerializeObject(aList.ToArray());
                                System.IO.File.WriteAllText(path, json);
                            }
                            else {
                                System.Console.WriteLine("GAY SHIT");
                            }

                            SY_ViewCases wnd = new SY_ViewCases();
                            wnd.Show();
                            Close();

                        }
                        else
                        {
                            MessageBox.Show("Case Name Has Already Existed!");

                        }
                    }
                    else
                    {
                        Console.WriteLine("Null or Empty");

                    }
                }
                else
                {
                    Console.WriteLine("Null or Empty");
                }
            }
            else
            {
                Console.WriteLine("Null or Empty");
            }

        }


        private void AddName(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(insertName.Text)))

            {
                investList.Items.Add(insertName.Text);


            }
            else
            {
                Console.WriteLine("Null or Empty");

            }
        }



        private void Remove_From_List(object sender, RoutedEventArgs e)
        {
            try
            {
                investList.Items.RemoveAt(investList.Items.IndexOf(investList.SelectedItem));

            }
            catch (Exception a)
            {
                if (a.Source != null)
                {
                    Console.WriteLine("ERROR: ", a.Source);

                }
            }
        }

    }
}
