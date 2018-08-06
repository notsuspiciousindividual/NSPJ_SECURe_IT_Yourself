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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SY_NewCase : Window
    {
        public SY_NewCase()
        {
            InitializeComponent();
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_NetworkStart wnd = new SY_NetworkStart();
            wnd.Show();
            this.Close();

        }

        private void Verify_Next(object sender, RoutedEventArgs e)
        {

            //Validation
            if (!(String.IsNullOrEmpty(case_name.Text)))
            {
                if (!(String.IsNullOrEmpty(case_desc.Text)))
                {
                    if (!(investList.Items.Count==0))
                    {
                        CaseDAO db = new CaseDAO();

                        
                        //Push to next page and ask for network file
                        String CName = case_name.Text;
                        String CDesc = case_desc.Text;
                        if (db.checkIfCaseName(CName))
                        {
                            ArrayList aList = new ArrayList();
                            for (int i = 0; i < investList.Items.Count; i++)
                            {
                                ListBoxItem item = (ListBoxItem)(investList.ItemContainerGenerator.ContainerFromIndex(i));
                                aList.Add(item.Content.ToString());
                            }

                            SY_NetworkLogUpload wnd = new SY_NetworkLogUpload(CName, CDesc, aList);
                            wnd.Show();
                            Close();
                        }
                        else {
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
            else {
                Console.WriteLine("Null or Empty");
            }

        }


        private void AddName(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(insertName.Text)))

            {
                investList.Items.Add(insertName.Text);
                

            }
            else {
                Console.WriteLine("Null or Empty");

            }
        }



        private void Remove_From_List(object sender, RoutedEventArgs e)
        {
            try
            {
                investList.Items.RemoveAt(investList.Items.IndexOf(investList.SelectedItem));

            }
            catch (Exception a) {
                if (a.Source != null) {
                    Console.WriteLine("ERROR: ", a.Source);

                }
            }
        }

    }
}
