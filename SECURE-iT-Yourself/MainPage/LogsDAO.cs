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

            string query = "SELECT COUNT(*) FROM Network_Log WHERE Log_Name = @logName";


            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query,myConnection))
            {
                cmd.Parameters.AddWithValue("@logName", LogName);
                myConnection.Open();

                int LogExist = (int)cmd.ExecuteScalar();

                myConnection.Close();

                if (LogExist > 0)
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



        public Boolean addLogToTable(String LogName, String LogDesc, int caseId, String File_Path, String File_Format)
        {
            Boolean checker = false;


            string query = "INSERT INTO Network_Log (Log_Name,Log_Desc,Case_Id,File_Path,Log_Format) VALUES (@LogName,@LogDesc,@Id,@filePath,@fileFormat)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {

                cmd.Parameters.AddWithValue("@LogName", LogName);
                cmd.Parameters.AddWithValue("@LogDesc", LogDesc);
                cmd.Parameters.AddWithValue("@Id", caseId);
                cmd.Parameters.AddWithValue("@filePath", File_Path);
                cmd.Parameters.AddWithValue("@fileFormat", File_Format);

                myConnection.Open();
                cmd.ExecuteScalar();
                myConnection.Close();

                checker = true;

            }





            return checker;
        }

        public Boolean deleteLogFromTable(String logName)
        {
            Boolean checker = false;

            try
            {

                string query = "DELETE FROM Network_Log WHERE Log_Name = @logName";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {

                    cmd.Parameters.AddWithValue("@logName", logName);

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

        public Boolean deleteThroughIdFromTable(int caseId) {
            Boolean checker = false;

            try
            {
                string query = "DELETE FROM Network_Log WHERE Case_Id = @id";
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@id", caseId);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            return checker;

        }


        public Boolean UpdateToTable(String logName, String logDesc, String PrevName)
        {
            Boolean checker = false;

            try
            {
                using (SqlConnection myConnection = new SqlConnection(connectionString))
                {

                    string query = "UPDATE Network_Log SET Log_Name = @newName, Log_Desc = @newDesc where Log_Name = @prevName";
                    SqlCommand cmd = new SqlCommand(query, myConnection);
                    cmd.Parameters.AddWithValue("@newName", logName);
                    cmd.Parameters.AddWithValue("@newDEsc", logDesc);
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
