using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainPage
{
    class SY_TagDAO
    {
        private String connectionString;

        public SY_TagDAO() {
            connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;
        }


        public Boolean addTagToTable(String LogName, int LogId)
        {
            Boolean checker = false;
            String path = @"C:\Users\Public\Documents\" + LogName + "_Taggings.txt";


            string query = "INSERT INTO Taggings (Log_Id, FilePath, Log_Name) VALUES (@LogId, @File, @LogName)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {

                cmd.Parameters.AddWithValue("@LogId", LogId);
                cmd.Parameters.AddWithValue("@File", path);
                cmd.Parameters.AddWithValue("@LogName", LogName);

                myConnection.Open();
                cmd.ExecuteScalar();
                myConnection.Close();

                checker = true;

            }

            return checker;
        }

        public Boolean deleteTagFile(String logName)
        {
            Boolean checker = false;
            String path = GetTaggingPath(logName);

            try
            {

                string query = "DELETE FROM Taggings WHERE Log_Name = @logName";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {

                    cmd.Parameters.AddWithValue("@logName", logName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;
                    System.IO.File.Delete(path);
                }


            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


            return checker;

        }





        public Boolean UpdateLogName(String logName, String OldName)
        {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Taggings SET Log_Name = @newName where Log_Name = @prevName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@newName", logName);
                    cmd.Parameters.AddWithValue("@prevName", OldName);

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

        public String GetTaggingPath(String logName) {
            String path = "";

            try
            {

                string query = "SELECT FilePath FROM Taggings WHERE Log_Name = @logName";

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@logName", logName);

                    myConnection.Open();
                    path = (String)cmd.ExecuteScalar();
                    myConnection.Close();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return path;
        }


    }
}
