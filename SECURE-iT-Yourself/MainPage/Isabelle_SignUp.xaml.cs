using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MainPage
{
    /// <summary>
    /// Interaction logic for Isabelle_SignUp.xaml
    /// </summary>
    public partial class Isabelle_SignUp : Window
    {

       
        public Isabelle_SignUp()
        {
            InitializeComponent();

            //connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.Isabelle_DatabaseConnectionString"].ConnectionString;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            Isabelle_Login login = new Isabelle_Login();
            login.Show();
            Close();
        }



        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter your email";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();

            }
            else
            {
                string firstname = textBoxFirstName.Text;
                string lastname = textBoxLastName.Text;
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;
                if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Enter password";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Enter confirm password";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "confirm password has to be the same as password";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    errormessage.Text = "";
                    string PhoneNumber = textBoxPhoneNumber.Text;
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Isabelle_Database.mdf;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Isabelle_SignUp (FirstName,LastName,Email,Password,PhoneNumber) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + PhoneNumber + "')", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();

                    errormessage.Text = "You have signed up successfully";
                    // process to login page
                }
}
}
              
        }
      
       
    }

