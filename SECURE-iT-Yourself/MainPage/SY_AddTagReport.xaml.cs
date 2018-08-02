using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SY_AddTagReport.xaml
    /// </summary>
    public partial class SY_AddTagReport : Window
    {
        private String logName = "";
        private String CName = "";

        public SY_AddTagReport(String logName, String CName)
        {
            InitializeComponent();
            this.logName = logName;
            this.CName = CName;
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(TagName.Text)) && !(String.IsNullOrEmpty(TagDescription.Text)))
            {
                if (!(datePicker.SelectedDate == null) && !(datePickerEnd.SelectedDate == null))
                {
                    if (!(StartHour.Text.Count() > 2) && !(String.IsNullOrEmpty(StartHour.Text)) && !(Int32.Parse(StartHour.Text) > 23))
                    {
                        if (!(StartMinute.Text.Count() > 2) && !(String.IsNullOrEmpty(StartMinute.Text)) && !(Int32.Parse(StartMinute.Text) > 59))
                        {
                            if (!(StartSeconds.Text.Count() > 2) && !(String.IsNullOrEmpty(StartSeconds.Text)) && !(Int32.Parse(StartHour.Text) > 59))
                            {
                                if (!(EndHour.Text.Count() > 2) && !(String.IsNullOrEmpty(EndHour.Text)) && !(Int32.Parse(EndHour.Text) > 23))
                                {
                                    if (!(EndMinute.Text.Count() > 2) && !(String.IsNullOrEmpty(EndMinute.Text)) && !(Int32.Parse(EndMinute.Text) > 59))
                                    {
                                        if (!(EndSeconds.Text.Count() > 2) && !(String.IsNullOrEmpty(EndSeconds.Text)) && !(Int32.Parse(EndSeconds.Text) > 59))
                                        {
                                            DateTime? selectedDate = datePicker.SelectedDate;
                                            string formatted = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                                            string[] splitted = formatted.Split(new char[] { '-' });
                                            Console.WriteLine(splitted[0]);

                                            DateTime? endDate = datePickerEnd.SelectedDate;
                                            string formatted2 = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                                            string[] splitted2 = formatted.Split(new char[] { '-' });
                                            Console.WriteLine(splitted2[0]);

                                            DateTime startTime = new DateTime(Int32.Parse(splitted[0]), Int32.Parse(splitted[1]), Int32.Parse(splitted[2]), Int32.Parse(StartHour.Text), Int32.Parse(StartMinute.Text), Int32.Parse(StartSeconds.Text));
                                            DateTime endTime = new DateTime(Int32.Parse(splitted2[0]), Int32.Parse(splitted2[1]), Int32.Parse(splitted2[2]), Int32.Parse(EndHour.Text), Int32.Parse(EndMinute.Text), Int32.Parse(EndSeconds.Text));

                                            SY_TagDAO tagdb = new SY_TagDAO();
                                            String filepath = tagdb.GetTaggingPath(logName);
                                            List<SY_Tag> list;
                                            using (StreamReader r = new StreamReader(filepath)) {
                                                String json = r.ReadToEnd();
                                                list = JsonConvert.DeserializeObject<List<SY_Tag>>(json);
                                                   

                                                
                                            }
                                            if (list != null && (!list.Any()))
                                            {
                                                list.Add(new SY_Tag(TagName.Text, TagDescription.Text, startTime, endTime));
                                            }
                                            else {
                                                list = new List<SY_Tag>();
                                                list.Add(new SY_Tag(TagName.Text, TagDescription.Text, startTime, endTime));
                                            }

                                           

                                            using (StreamWriter newTask = new StreamWriter(filepath, false))
                                                {
                                                JsonSerializer serializer = new JsonSerializer();
                                                serializer.Serialize(newTask, list);
                                            }


                                            SY_ViewSpecificTeam wnd = new SY_ViewSpecificTeam(logName, CName);
                                            wnd.Show();
                                            Close();

                                            

                                        }
                                        else
                                        {
                                            MessageBox.Show("Incorrect Input");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Incorrect Input");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Input");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Input");
                            }
                        }
                        else {
                            MessageBox.Show("Incorrect Input");
                        }
                    }
                    else {
                        MessageBox.Show("Incorrect Input");
                    }

                }
                else {
                    MessageBox.Show("Please Fill in the Blanks");
                }

            }
            else {
                MessageBox.Show("Please Fill in the Blanks");
            }
        }

       

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_ViewSpecificTeam wnd = new SY_ViewSpecificTeam(logName, CName);
            wnd.Show();
            Close();

        }
    }
}
