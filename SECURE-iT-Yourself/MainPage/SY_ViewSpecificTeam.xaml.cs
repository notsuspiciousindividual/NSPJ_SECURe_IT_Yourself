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
    /// Interaction logic for SY_ViewSpecificTeam.xaml
    /// </summary>
    public partial class SY_ViewSpecificTeam : Window
    {
        private String logName = "";
        private String logPath = "";
        private String logFormat = "";
        private List<SY_Sort_Windows> windowItems;
        
        public SY_ViewSpecificTeam(string logName)
        {
            this.logName = logName;
            LogsDAO logdb = new LogsDAO();
            logPath = logdb.getLogFilePath(logName);
            logFormat = logdb.getLogFormat(logName);

            InitializeComponent();

            fillListBox();


        }

        private void fillTagBox() {

        }

        private void fillListBox() {
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
                    txtBlock.Text = "Date: " + test.dateSpecific.Year.ToString() + "-" + test.dateSpecific.Month.ToString() + "-" + test.dateSpecific.Day.ToString();
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


            }

        }

        private void Create_Anomaly(object sender, RoutedEventArgs e)
        {

        }

        private void ScanWithAi(object sender, RoutedEventArgs e)
        {

        }
    }
}
