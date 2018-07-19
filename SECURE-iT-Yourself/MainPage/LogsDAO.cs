using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainPage
{
    class LogsDAO
    {
        private String connectionString;

        public LogsDAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;
        }



        public Boolean checkIfLogs(String LogName)
        {
            Boolean checker = false;

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) from Network_Log where Log_Name=@logName";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@logName", LogName);
                myConnection.Open();

                int CaseNameExist = (int)cmd.ExecuteScalar();

                if (CaseNameExist > 0)
                {
                    checker = false;
                }
                else
                {
                    checker = true;
                }

            }

            return checker;


        }



        public Boolean addLogToTable(String caseName, String caseDesc)
        {
            Boolean checker = false;

            Random rnd = new Random();
            int number = rnd.Next(1, 9999);
            String APath = "C:\\Users\\Public]Documents\\S" + number + ".txt";



            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO Cases (C_Name,C_Authors_Path,C_Description) VALUES (@CaseName,@CAuthors,@CaseDesc)";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@CaseName", caseName);
                cmd.Parameters.AddWithValue("@CAuthors", APath);
                cmd.Parameters.AddWithValue("@CaseDesc", caseDesc);

                myConnection.Open();
                cmd.ExecuteScalar();
                myConnection.Close();

                checker = true;

            }





            return checker;
        }

        public Boolean deleteCaseFromTable(String caseName)
        {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {

                    string query = "DELETE FROM Cases WHERE C_Name = @cName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@cName", caseName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            return checker;

        }

        public Boolean updateToTable(Case cName, String PrevName)
        {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Cases SET C_Name = @newName, C_Description = @newDesc where C_Name = @prevName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@newName", cName.C_Name);
                    cmd.Parameters.AddWithValue("@newDEsc", cName.C_Desc);
                    cmd.Parameters.AddWithValue("@prevName", PrevName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return checker;

        }


    }
}
