using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for SY_ViewSpecificTeam.xaml
    /// </summary>
    public partial class SY_ViewSpecificTeam : Window
    {
        private String cName = "";
        private String logName = "";
        private String logPath = "";
        private String logFormat = "";
        private Boolean checker = true;
        private List<SY_Sort_Windows> windowItems;
        private List<SY_Sort_PCap> pCapItems;

        public SY_ViewSpecificTeam(string logName, string cName)
        {
            

            this.logName = logName;
            this.cName = cName;
            LogsDAO logdb = new LogsDAO();
            logPath = logdb.getLogFilePath(logName);
            logFormat = logdb.getLogFormat(logName);

            InitializeComponent();

            CaseName.Content = logName;

            FillListBox();
            FillTagBox();

            

        }

        private void FillTagBox() {
            SY_TagDAO tagdb = new SY_TagDAO();
            String file = tagdb.GetTaggingPath(logName);
            List<SY_Tag> items = new List<SY_Tag>();

            using (StreamReader r = new StreamReader(file)) {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<SY_Tag>>(json);
            }

            if ((items != null) && (items.Any()))
            {
                foreach (SY_Tag line in items)
                {

                    Grid DynamicGrid = new Grid();

                    DynamicGrid.Height = 150;
                    DynamicGrid.Background = new SolidColorBrush(Color.FromRgb(57, 66, 77));

                    RowDefinition gridRow1 = new RowDefinition();
                    gridRow1.Height = new GridLength(20);
                    RowDefinition gridRow2 = new RowDefinition();
                    gridRow2.Height = new GridLength(20);
                    RowDefinition gridRow3 = new RowDefinition();
                    gridRow3.Height = new GridLength(20);
                    RowDefinition gridRow4 = new RowDefinition();
                    gridRow4.Height = new GridLength(50);
                    RowDefinition gridRow5 = new RowDefinition();
                    gridRow5.Height = new GridLength(1, GridUnitType.Star);

                    ColumnDefinition gridCol1 = new ColumnDefinition();
                    gridCol1.Width = new GridLength(1, GridUnitType.Auto);
                    ColumnDefinition gridCol2 = new ColumnDefinition();
                    gridCol2.Width = new GridLength(1, GridUnitType.Star);

                    DynamicGrid.ColumnDefinitions.Add(gridCol1);
                    DynamicGrid.ColumnDefinitions.Add(gridCol2);


                    DynamicGrid.RowDefinitions.Add(gridRow1);
                    DynamicGrid.RowDefinitions.Add(gridRow2);
                    DynamicGrid.RowDefinitions.Add(gridRow3);
                    DynamicGrid.RowDefinitions.Add(gridRow4);
                    DynamicGrid.RowDefinitions.Add(gridRow5);

                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = "Tag's Name: ";
                    txtBlock.FontSize = 14;
                    txtBlock.HorizontalAlignment = HorizontalAlignment.Right;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 0);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = line.TagName;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetColumn(txtBlock, 1);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = "Time Started: ";
                    txtBlock.FontSize = 14;
                    txtBlock.HorizontalAlignment = HorizontalAlignment.Right;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 1);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = line.timeStart.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 1);
                    Grid.SetColumn(txtBlock, 1);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = "Time Ended: ";
                    txtBlock.FontSize = 14;
                    txtBlock.HorizontalAlignment = HorizontalAlignment.Right;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 2);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = line.timeEnd.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 2);
                    Grid.SetColumn(txtBlock, 1);
                    DynamicGrid.Children.Add(txtBlock);


                    txtBlock = new TextBlock();
                    txtBlock.Text = "Tag's Description: ";
                    txtBlock.FontSize = 14;
                    txtBlock.TextWrapping = TextWrapping.Wrap;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 3);
                    DynamicGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = line.TagDesc;
                    txtBlock.FontSize = 14;
                    txtBlock.TextWrapping = TextWrapping.Wrap;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    txtBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    Grid.SetRow(txtBlock, 3);
                    Grid.SetColumn(txtBlock, 1);
                    DynamicGrid.Children.Add(txtBlock);

                    StackPanel panel = new StackPanel();
                    panel.Height = 30;
                    panel.Orientation = Orientation.Horizontal;
                    Grid.SetColumn(panel, 0);
                    Grid.SetRow(panel, 4);
                    Grid.SetColumnSpan(panel, 2);

                    Rectangle rect = new Rectangle();
                    rect.Width = 5;
                    panel.Children.Add(rect);

                    Button ViewBtn = new Button();
                    ViewBtn.Content = "View";
                    ViewBtn.Background = new SolidColorBrush(Color.FromRgb(34, 139, 34));
                    ViewBtn.FontSize = 15;
                    ViewBtn.Click += new RoutedEventHandler(View_Action);


                    Button Deletebtn = new Button();
                    Deletebtn.Content = "Delete";
                    Deletebtn.FontSize = 15;
                    Deletebtn.Background = new SolidColorBrush(Color.FromRgb(178, 34, 34));
                    Deletebtn.Click += new RoutedEventHandler(Remove_Action);

                    rect = new Rectangle();
                    rect.Width = 210;

                    panel.Children.Add(ViewBtn);
                    panel.Children.Add(rect);
                    panel.Children.Add(Deletebtn);
                    DynamicGrid.Children.Add(panel);

                    

                    AnomalyList.Items.Add(DynamicGrid);

                    

                }
            }
            else {
                

                AnomalyList.Visibility = Visibility.Hidden;

                
            }

        }

        private void Remove_Action(object sender, EventArgs e) {
            var button = sender as DependencyObject;

            while ((button != null) && !(button is Grid)) {
                button = VisualTreeHelper.GetParent(button);
            }

            if (button is Grid) {
                Grid dynamicGrid = button as Grid;

                UIElement ex;

                TextBlock TagName = new TextBlock();
                TextBlock TagDesc = new TextBlock();
                TextBlock StartTime = new TextBlock();
                TextBlock EndTime = new TextBlock();


                for (int i = 0; i < dynamicGrid.Children.Count; i++) {
                    ex = dynamicGrid.Children[i];

                    if (Grid.GetRow(ex) == 0 && Grid.GetColumn(ex) == 1) {

                        TagName = ex as TextBlock;
                        
                    }

                    if (Grid.GetRow(ex) == 1 && Grid.GetColumn(ex) == 1) {
                        StartTime = ex as TextBlock;
                        
                    }

                    if (Grid.GetRow(ex) == 2 && Grid.GetColumn(ex) == 1) {
                        EndTime = ex as TextBlock;
                        
                    }

                    if (Grid.GetRow(ex) == 3 && Grid.GetColumn(ex) == 1) {
                        TagDesc = ex as TextBlock;
                        
                    }
                }

                String startTime = StartTime.Text;
                String endTime = EndTime.Text;


                String[] StartSplitter = startTime.Split(new char[] { ' ' });
                String[] StartDate = StartSplitter[0].Split(new char[] { '/' });
                String[] StartTiming = StartSplitter[1].Split(new char[] { ':' });

                String[] EndSplitter = endTime.Split(new char[] { ' ' });
                String[] EndDate = EndSplitter[0].Split(new char[] { '/' });
                String[] EndTiming = EndSplitter[1].Split(new char[] { ':' });

                DateTime start = new DateTime(Int32.Parse(StartDate[2]), Int32.Parse(StartDate[1]), Int32.Parse(StartDate[0]), Int32.Parse(StartTiming[0]), Int32.Parse(StartTiming[1]), Int32.Parse(StartTiming[2]));
                DateTime end = new DateTime(Int32.Parse(EndDate[2]), Int32.Parse(EndDate[1]), Int32.Parse(EndDate[0]), Int32.Parse(EndTiming[0]), Int32.Parse(EndTiming[1]), Int32.Parse(EndTiming[2]));

                SY_TagDAO tagdb = new SY_TagDAO();
                string filepath = tagdb.GetTaggingPath(logName);

                SY_Tag toRemove = new SY_Tag(TagName.Text, TagDesc.Text, start, end);
                List<SY_Tag> items = new List<SY_Tag>();

                using (StreamReader r = new StreamReader(filepath))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<SY_Tag>>(json);
                }


                foreach (SY_Tag Tag in items) {
                    if (String.Equals(toRemove.TagName, Tag.TagName) && String.Equals(toRemove.TagDesc, Tag.TagDesc) && toRemove.timeStart.Date == Tag.timeStart.Date && toRemove.timeEnd.Date == Tag.timeEnd.Date ) {
                        items.Remove(Tag);
                        Console.WriteLine("Remove");
                        break;
                    }
                }

                

                using (StreamWriter newTask = new StreamWriter(filepath, false))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(newTask, items);
                }

                FillTagBox();

            }
            

        }

        private void View_Action(object sender, EventArgs e)
        {
            var button = sender as DependencyObject;

            while ((button != null) && !(button is Grid))
            {
                button = VisualTreeHelper.GetParent(button);
            }

            if (button is Grid)
            {
                if (checker)
                {
                    Grid dynamicGrid = button as Grid;
                    dynamicGrid.Background = new SolidColorBrush(Color.FromRgb(178, 34, 34));

                    UIElement ex;

                    TextBlock TagName = new TextBlock();
                    TextBlock TagDesc = new TextBlock();
                    TextBlock StartTime = new TextBlock();
                    TextBlock EndTime = new TextBlock();

                    for (int i = 0; i < dynamicGrid.Children.Count; i++)
                    {
                        ex = dynamicGrid.Children[i];

                        if (Grid.GetRow(ex) == 0 && Grid.GetColumn(ex) == 1)
                        {

                            TagName = ex as TextBlock;
                        }

                        if (Grid.GetRow(ex) == 1 && Grid.GetColumn(ex) == 1)
                        {
                            StartTime = ex as TextBlock;
                        }

                        if (Grid.GetRow(ex) == 2 && Grid.GetColumn(ex) == 1)
                        {
                            EndTime = ex as TextBlock;
                        }

                        if (Grid.GetRow(ex) == 3 && Grid.GetColumn(ex) == 1)
                        {
                            TagDesc = ex as TextBlock;
                        }
                    }

                    String startTime = StartTime.Text;
                    String endTime = EndTime.Text;


                    String[] StartSplitter = startTime.Split(new char[] { ' ' });
                    String[] StartDate = StartSplitter[0].Split(new char[] { '/' });
                    String[] StartTiming = StartSplitter[1].Split(new char[] { ':' });

                    String[] EndSplitter = endTime.Split(new char[] { ' ' });
                    String[] EndDate = EndSplitter[0].Split(new char[] { '/' });
                    String[] EndTiming = EndSplitter[1].Split(new char[] { ':' });

                    DateTime start = new DateTime(Int32.Parse(StartDate[2]), Int32.Parse(StartDate[1]), Int32.Parse(StartDate[0]), Int32.Parse(StartTiming[0]), Int32.Parse(StartTiming[1]), Int32.Parse(StartTiming[2]));
                    DateTime end = new DateTime(Int32.Parse(EndDate[2]), Int32.Parse(EndDate[1]), Int32.Parse(EndDate[0]), Int32.Parse(EndTiming[0]), Int32.Parse(EndTiming[1]), Int32.Parse(EndTiming[2]));

                    SY_TagDAO tagdb = new SY_TagDAO();
                    string filepath = tagdb.GetTaggingPath(logName);

                    SY_Tag toRemove = new SY_Tag(TagName.Text, TagDesc.Text, start, end);

                    if (logFormat.Equals("Window Firewall"))
                    {
                        windowItems = new List<SY_Sort_Windows>();

                        String[] lines = System.IO.File.ReadAllLines(logPath);
                        foreach (String line in lines)
                        {
                            windowItems.Add(new SY_Sort_Windows(line));
                        }

                        List<SY_Sort_Windows> withinRange = new List<SY_Sort_Windows>();

                        foreach (SY_Sort_Windows stuff in windowItems)
                        {
                            if (stuff.dateSpecific >= toRemove.timeStart && stuff.dateSpecific <= toRemove.timeEnd)
                            {
                                withinRange.Add(stuff);

                            }
                        }

                        LogData.Items.Clear();

                        foreach (SY_Sort_Windows test in withinRange)
                        {

                            Grid DynamicGrid = new Grid();
                            DynamicGrid.Height = 100;
                            DynamicGrid.MinWidth = 500;
                            DynamicGrid.Background = new SolidColorBrush(Color.FromRgb(156, 202, 224));

                            RowDefinition gridRow1 = new RowDefinition();
                            gridRow1.Height = new GridLength(20);
                            RowDefinition gridRow2 = new RowDefinition();
                            gridRow2.Height = new GridLength(20);
                            RowDefinition gridRow3 = new RowDefinition();
                            gridRow3.Height = new GridLength(20);

                            DynamicGrid.RowDefinitions.Add(gridRow1);
                            DynamicGrid.RowDefinitions.Add(gridRow2);
                            DynamicGrid.RowDefinitions.Add(gridRow3);

                            //Second Grid
                            Grid SecondGrid = new Grid();
                            ColumnDefinition gridColumn1 = new ColumnDefinition();
                            gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                            ColumnDefinition gridColumn2 = new ColumnDefinition();
                            gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                            ColumnDefinition gridColumn3 = new ColumnDefinition();
                            gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                            ColumnDefinition gridColumn4 = new ColumnDefinition();
                            gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                            ColumnDefinition gridColumn5 = new ColumnDefinition();
                            gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                            ColumnDefinition gridColumn6 = new ColumnDefinition();
                            gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                            SecondGrid.ColumnDefinitions.Add(gridColumn1);
                            SecondGrid.ColumnDefinitions.Add(gridColumn2);
                            SecondGrid.ColumnDefinitions.Add(gridColumn3);
                            SecondGrid.ColumnDefinitions.Add(gridColumn4);
                            SecondGrid.ColumnDefinitions.Add(gridColumn5);
                            SecondGrid.ColumnDefinitions.Add(gridColumn6);

                            //Stack Panel for Row 1
                            StackPanel panel1 = new StackPanel();
                            panel1.Orientation = Orientation.Horizontal;

                            //Third Grid
                            Grid ThirdGrid = new Grid();
                            gridColumn1 = new ColumnDefinition();
                            gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                            gridColumn2 = new ColumnDefinition();
                            gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                            gridColumn3 = new ColumnDefinition();
                            gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                            gridColumn4 = new ColumnDefinition();
                            gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                            gridColumn5 = new ColumnDefinition();
                            gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                            gridColumn6 = new ColumnDefinition();
                            gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn1);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn2);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn3);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn4);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn5);
                            ThirdGrid.ColumnDefinitions.Add(gridColumn6);

                            //Items for Second Grid Row 2
                            TextBlock txtBlock = new TextBlock();
                            txtBlock.Text = "Date: " + test.dateSpecific.Year.ToString() + "." + test.dateSpecific.Month.ToString() + "." + test.dateSpecific.Day.ToString();
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            panel1.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Time: " + test.dateSpecific.Hour.ToString() + ":" + test.dateSpecific.Minute.ToString() + ":" + test.dateSpecific.Second.ToString();
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            panel1.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = "Source IP: " + test.SRCIP;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 0);
                            SecondGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Source Port: " + test.SRCPort;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 1);
                            SecondGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Destination IP: " + test.DSTIP;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 2);
                            SecondGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Destination Port: " + test.DSTPort;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 3);
                            SecondGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Size of Packet: " + test.SizePackage;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 4);
                            SecondGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Protocol: " + test.protocol;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 5);
                            SecondGrid.Children.Add(txtBlock);

                            //Items for Third Grid, Row 3

                            txtBlock = new TextBlock();
                            txtBlock.Text = "TCP Syn: " + test.TCPSyn;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 0);
                            ThirdGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " TCP ACK: " + test.TCpack;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 1);
                            ThirdGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " TCP Window Size: " + test.TCPwin;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 2);
                            ThirdGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " ICMP Type: " + test.ICMPType;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 3);
                            ThirdGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Path: " + test.Path;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 4);
                            ThirdGrid.Children.Add(txtBlock);

                            txtBlock = new TextBlock();
                            txtBlock.Text = " Path: " + test.Path;
                            txtBlock.FontSize = 14;
                            txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                            Grid.SetColumn(txtBlock, 4);
                            ThirdGrid.Children.Add(txtBlock);


                            //Adding Items Yes
                            Grid.SetRow(SecondGrid, 1);
                            Grid.SetRow(panel1, 0);
                            Grid.SetRow(ThirdGrid, 2);
                            DynamicGrid.Children.Add(panel1);
                            DynamicGrid.Children.Add(SecondGrid);
                            DynamicGrid.Children.Add(ThirdGrid);

                            LogData.Items.Add(DynamicGrid);

                            
                        }

                        checker = false;
                        Console.WriteLine("checker is false!");
                    }
                    else if (logFormat.Equals(".PCAP"))
                    {


                    }



                }
                else {
                    Console.WriteLine("Works");
                    Grid dynamicGrid = button as Grid;
                    dynamicGrid.Background = new SolidColorBrush(Color.FromRgb(57, 66, 77));

                    AnomalyList.Items.Refresh();
                    LogData.Items.Clear();
                    FillListBox();
                    checker = true;
                }
            }
        }

        private void FillListBox() {
            if (logFormat.Equals("Window Firewall"))
            {

                windowItems = new List<SY_Sort_Windows>();

                String[] lines = System.IO.File.ReadAllLines(logPath);
                foreach (String line in lines) {
                    windowItems.Add(new SY_Sort_Windows(line));
                }

                foreach (SY_Sort_Windows test in windowItems)
                {

                    Grid DynamicGrid = new Grid();
                    DynamicGrid.Height = 100;
                    DynamicGrid.MinWidth = 500;
                    DynamicGrid.Background = new SolidColorBrush(Color.FromRgb(156, 202, 224));

                    RowDefinition gridRow1 = new RowDefinition();
                    gridRow1.Height = new GridLength(20);
                    RowDefinition gridRow2 = new RowDefinition();
                    gridRow2.Height = new GridLength(20);
                    RowDefinition gridRow3 = new RowDefinition();
                    gridRow3.Height = new GridLength(20);

                    DynamicGrid.RowDefinitions.Add(gridRow1);
                    DynamicGrid.RowDefinitions.Add(gridRow2);
                    DynamicGrid.RowDefinitions.Add(gridRow3);
                    
                    //Second Grid
                    Grid SecondGrid = new Grid();
                    ColumnDefinition gridColumn1 = new ColumnDefinition();
                    gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn2 = new ColumnDefinition();
                    gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn3 = new ColumnDefinition();
                    gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn4 = new ColumnDefinition();
                    gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn5 = new ColumnDefinition();
                    gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn6 = new ColumnDefinition();
                    gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                    SecondGrid.ColumnDefinitions.Add(gridColumn1);
                    SecondGrid.ColumnDefinitions.Add(gridColumn2);
                    SecondGrid.ColumnDefinitions.Add(gridColumn3);
                    SecondGrid.ColumnDefinitions.Add(gridColumn4);
                    SecondGrid.ColumnDefinitions.Add(gridColumn5);
                    SecondGrid.ColumnDefinitions.Add(gridColumn6);

                    //Stack Panel for Row 1
                    StackPanel panel1 = new StackPanel();
                    panel1.Orientation = Orientation.Horizontal;

                    //Third Grid
                    Grid ThirdGrid = new Grid();
                    gridColumn1 = new ColumnDefinition();
                    gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn2 = new ColumnDefinition();
                    gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn3 = new ColumnDefinition();
                    gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn4 = new ColumnDefinition();
                    gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn5 = new ColumnDefinition();
                    gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn6 = new ColumnDefinition();
                    gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn1);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn2);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn3);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn4);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn5);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn6);

                    //Items for Second Grid Row 2
                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = "Date: " + test.dateSpecific.Year.ToString() + "." + test.dateSpecific.Month.ToString() + "." + test.dateSpecific.Day.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    panel1.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Time: " + test.dateSpecific.Hour.ToString() + ":" + test.dateSpecific.Minute.ToString() + ":" + test.dateSpecific.Second.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    panel1.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = "Source IP: " + test.SRCIP;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 0);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Source Port: " + test.SRCPort;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 1);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Destination IP: " + test.DSTIP;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 2);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Destination Port: " + test.DSTPort;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 3);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Size of Packet: " + test.SizePackage;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 4);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Protocol: " + test.protocol;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 5);
                    SecondGrid.Children.Add(txtBlock);

                    //Items for Third Grid, Row 3

                    txtBlock = new TextBlock();
                    txtBlock.Text = "TCP Syn: " + test.TCPSyn;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 0);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " TCP ACK: " + test.TCpack;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 1);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " TCP Window Size: " + test.TCPwin;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 2);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " ICMP Type: " + test.ICMPType;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 3);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Path: " + test.Path;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 4);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Path: " + test.Path;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 4);
                    ThirdGrid.Children.Add(txtBlock);


                    //Adding Items Yes
                    Grid.SetRow(SecondGrid, 1);
                    Grid.SetRow(panel1, 0);
                    Grid.SetRow(ThirdGrid, 2);
                    DynamicGrid.Children.Add(panel1);
                    DynamicGrid.Children.Add(SecondGrid);
                    DynamicGrid.Children.Add(ThirdGrid);



                    LogData.Items.Add(DynamicGrid);

                }

                


            }
            else if (logFormat.Equals(".PCAP"))
            {
                SY_Sort_PCap pcap = new SY_Sort_PCap(logPath);
                pCapItems = pcap.getList();

                foreach (SY_Sort_PCap test in pCapItems) {
                    Grid DynamicGrid = new Grid();
                    DynamicGrid.Height = 100;
                    DynamicGrid.MinWidth = 500;
                    DynamicGrid.Background = new SolidColorBrush(Color.FromRgb(156, 202, 224));

                    RowDefinition gridRow1 = new RowDefinition();
                    gridRow1.Height = new GridLength(20);
                    RowDefinition gridRow2 = new RowDefinition();
                    gridRow2.Height = new GridLength(20);
                    RowDefinition gridRow3 = new RowDefinition();
                    gridRow3.Height = new GridLength(20);

                    DynamicGrid.RowDefinitions.Add(gridRow1);
                    DynamicGrid.RowDefinitions.Add(gridRow2);
                    DynamicGrid.RowDefinitions.Add(gridRow3);

                    //Second Grid
                    Grid SecondGrid = new Grid();
                    ColumnDefinition gridColumn1 = new ColumnDefinition();
                    gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn2 = new ColumnDefinition();
                    gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn3 = new ColumnDefinition();
                    gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn4 = new ColumnDefinition();
                    gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn5 = new ColumnDefinition();
                    gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                    ColumnDefinition gridColumn6 = new ColumnDefinition();
                    gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                    SecondGrid.ColumnDefinitions.Add(gridColumn1);
                    SecondGrid.ColumnDefinitions.Add(gridColumn2);
                    SecondGrid.ColumnDefinitions.Add(gridColumn3);
                    SecondGrid.ColumnDefinitions.Add(gridColumn4);
                    SecondGrid.ColumnDefinitions.Add(gridColumn5);
                    SecondGrid.ColumnDefinitions.Add(gridColumn6);

                    //Stack Panel for Row 1
                    StackPanel panel1 = new StackPanel();
                    panel1.Orientation = Orientation.Horizontal;

                    //Third Grid
                    Grid ThirdGrid = new Grid();
                    gridColumn1 = new ColumnDefinition();
                    gridColumn1.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn2 = new ColumnDefinition();
                    gridColumn2.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn3 = new ColumnDefinition();
                    gridColumn3.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn4 = new ColumnDefinition();
                    gridColumn4.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn5 = new ColumnDefinition();
                    gridColumn5.Width = new GridLength(1, GridUnitType.Star);
                    gridColumn6 = new ColumnDefinition();
                    gridColumn6.Width = new GridLength(1, GridUnitType.Star);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn1);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn2);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn3);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn4);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn5);
                    ThirdGrid.ColumnDefinitions.Add(gridColumn6);

                    //Items for Second Grid Row 2
                    TextBlock txtBlock = new TextBlock();
                    txtBlock.Text = "Date: " + test.Captured.Year.ToString() + "." + test.Captured.Month.ToString() + "." + test.Captured.Day.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    panel1.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Time: " + test.Captured.Hour.ToString() + ":" + test.Captured.Minute.ToString() + ":" + test.Captured.Second.ToString();
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    panel1.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = "Source IP: " + test.SRCIP;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 0);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Source Port: " + test.SRCPort;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 1);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Destination IP: " + test.DSTIP;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 2);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Destination Port: " + test.DSTPort;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 3);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " Protocol: " + test.Protocol;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 4);
                    SecondGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " TCP Flag: " + test.TCPFlags;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 5);
                    SecondGrid.Children.Add(txtBlock);

                    //Items for Third Grid, Row 3

                    txtBlock = new TextBlock();
                    txtBlock.Text = "TCP Syn: " + test.TCPSYN;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 0);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " TCP ACK: " + test.TCPACK;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 1);
                    ThirdGrid.Children.Add(txtBlock);

                    txtBlock = new TextBlock();
                    txtBlock.Text = " TCP Window Size: " + test.TCPWin;
                    txtBlock.FontSize = 14;
                    txtBlock.FontFamily = new FontFamily("/MainPage;component/Fonts/#Apex New Light");
                    Grid.SetColumn(txtBlock, 2);
                    ThirdGrid.Children.Add(txtBlock);

                    //Adding Items Yes
                    Grid.SetRow(SecondGrid, 1);
                    Grid.SetRow(panel1, 0);
                    Grid.SetRow(ThirdGrid, 2);
                    DynamicGrid.Children.Add(panel1);
                    DynamicGrid.Children.Add(SecondGrid);
                    DynamicGrid.Children.Add(ThirdGrid);

                    LogData.Items.Add(DynamicGrid);
                }
            }

        }

        private void Create_Anomaly(object sender, RoutedEventArgs e)
        {
            SY_AddTagReport wnd = new SY_AddTagReport(logName, cName);
            wnd.Show();
            Close();

        }

        private void ScanWithAi(object sender, RoutedEventArgs e)
        {
            if (logFormat.Equals("Window Firewall"))
            {
                SY_ScanAnormalies potatoe = new SY_ScanAnormalies(windowItems, logName);
                potatoe.ScanAnormalies();
                AnomalyList.Items.Refresh();

    }
            else if (logFormat.Equals(".PCAP")) {

            }

        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            SY_ViewSpecificCase wnd = new SY_ViewSpecificCase(cName);
            wnd.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (logFormat.Equals("Window Firewall"))
            {


               
                string[] wordsToMatch = { "SRC.IP==", "DST.IP==", "SRC.Port==", "DST.Port==" , "SizePackage==" , "TCP.Flag==", "TCP.Syn==", "TCP.Ack==", "TCP.Win==", "ICMP.Type==", "ICMP.Info==", "Path=="};
                //creating string list for t
                List<String> SRCIPList = new List<String>();
                List<String> DSTIPList = new List<String>();
                List<String> SRCPORTList = new List<String>();
                List<String> DSTPORTList = new List<String>();
                List<String> SizePackageList = new List<String>();
                List<String> TCPFlagList = new List<String>();
                List<String> TCPSYNList = new List<String>();
                List<String> TCPAckList = new List<String>();
                List<String> TCPWinList = new List<String>();
                List<String> ICMPTypeList = new List<String>();
                List<String> IMCPInfoList = new List<String>();
                List<String> PathList = new List<String>();

                foreach (SY_Sort_Windows item in windowItems) {
                    SRCIPList.Add(item.SRCIP);
                    DSTIPList.Add(item.DSTIP);
                    SRCPORTList.Add(item.SRCPort);
                    DSTPORTList.Add(item.DSTPort);
                    SizePackageList.Add(item.SizePackage);
                    TCPFlagList.Add(item.TCPFlag);
                    TCPSYNList.Add(item.TCPSyn);
                    TCPAckList.Add(item.TCpack);
                    TCPWinList.Add(item.TCPwin);
                    ICMPTypeList.Add(item.ICMPType);
                    IMCPInfoList.Add(item.icmpinfo);
                    PathList.Add(item.Path);
                }

                //get user to input the field
                //use && to specify more than 1 field
                //use algorithm to get the number of fields via splitting
                //pass the items into an array
                //do a for loop for each array item, run the following algorithm
                //use algorithm to determine the type of field the item is
                //use algorithm to read what the item is after the "==" in your field
                //take the item read and matches them with the dictionary
                //if search result == true, return +
                //else return not found message

                String[] SplitByAnd = SearchBox.Text.Split(new Char[] { '&' });
                



            }
            else if (logFormat.Equals(".PCAP")) {

            }
        }
    }
}
