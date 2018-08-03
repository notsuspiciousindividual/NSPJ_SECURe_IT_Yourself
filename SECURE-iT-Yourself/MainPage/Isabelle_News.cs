using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Windows.Controls.Primitives;
//using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Linq;

namespace MainPage
{
    /// <summary>
    /// Interaction logic for Isabelle_News.xaml
    /// </summary>
    public partial class Isabelle_News : Window
    {
        public Isabelle_News()
        {
            InitializeComponent();

         

        }
        string[,] rssDara = null;

        private void Isabelle_News_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            TextBox1.Text = client.DownloadString("https://www.straitstimes.com/tags/cyber-security");
        }
    }
}
//    private void SearchButton1_Click(object sender, EventArgs e)
//{

//}

////        public static string[] Tokenize(this string value)
////        {
////            value = Regex.Replace(value, @"<.*?>", string
////                .Empty); //remove html tag
////            value = HttpUtility.HtmlDecode(value); // decode html characters
////            value = Regex.Replace(value, @"[^\w\s]", string.Empty); //remove everything but letter, numbers and whitespace characters
////            value = Regex.Replace(value, @"\s+", ""); //remove multiple whitespace characters
////            return value.Trim().ToLower().Split(''); //Trim, lower case and split into array
////        }

//       private String[,] getRssData(String channel)
//{



//    WebRequest myWebRequest;
//    WebResponse myWebResponse;
//   // String URL = TextBox_Search.Text;

//    myWebRequest = WebRequest.Create("https://www.straitstimes.com/tags/cyber-security");
//    myWebResponse = myWebRequest.GetResponse(); //Returns a response from an Internet resource

//    Stream streamResponse = myWebResponse.GetResponseStream();//return the data stream from the internet
//                                                              //and save it in the stream

//    XmlDocument rssDoc = new XmlDocument();
//    rssDoc.Load(streamResponse);

//    XmlNodeList rssItems = rssDoc.SelectNodes("");

//    String[,] tempRssData = new string[100, 3];

//    for(int i = 0; i < rssItems(i).Count; i++)
//    {
//        XmlNode rssNode;

//        rssNode = rssItems.Item(i).SelectSingleNode("title");
//        if(rssNode != null)
//        {
//            tempRssData[i, 0] = rssNode.InnerText;
//        }
//        else
//        {
//            tempRssData[i, 0] = " ";
//        }
//        rssNode = rssItems.Item(i).SelectSingleNode("decryption");
//        if(rssNode != null)
//        {
//            tempRssData[i, 1] = rssNode.InnerText;
//        }
//        else
//        {
//            tempRssData[i, 1] = " ";
//        }
//        rssNode = rssItems.Item(i).SelectSingleNode("link");
//    }
//    if (rssNode != null)
//    {
//        tempRssData[i, 2] = rssNode.InnerText;
//    }
//    else
//    {
//        tempRssData[1,2] = rssNode.InnerText;
//    }
//    //StreamReader sreader = new StreamReader(streamResponse);//reads the data stream
//    //string strData = sreader.ReadToEnd();//reads it to the end
//    //String Links = GetContent(strData);//gets the links only

//    //TextBox1.Text = strData;
//    //TextBox_Search.Text = Links;
//    //streamResponse.Close();
//    //sreader.Close();
//    //myWebResponse.Close();




//}


////        private string GetContent(object rstring)
////        {
////            throw new NotImplementedException();
////        }
////    }
////}
