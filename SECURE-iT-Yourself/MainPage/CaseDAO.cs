using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Forms;

namespace MainPage
{
    class CaseDAO
    {
        private string connectionString;


        public CaseDAO() {
           connectionString = ConfigurationManager.ConnectionStrings["MainPage.Properties.Settings.LocalDBConnectionString"].ConnectionString;
        }


        public Boolean checkIfCaseName(String caseName) {
            Boolean checker = false;



            string query = "SELECT count(*) from Cases where C_Name = @CaseName";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                myConnection.Open();
                cmd.Parameters.AddWithValue("@CaseName", caseName);
                int CaseNameExist = (int)cmd.ExecuteScalar();
                myConnection.Close();


                if (CaseNameExist > 0)
                {
                    checker = false;
                    Console.WriteLine("Case Existed Already");
                }
                else
                {
                    checker = true;
                    Console.WriteLine("Case Does Not Exist");
                }



            }

            return checker;


        }



        public Boolean addCaseToTable(String caseName, String caseDesc, ArrayList authors) {
            Boolean checker = false;

            Random rnd = new Random();
            int number = rnd.Next(1, 9999);
            String APath = "C:\\Users\\Public\\Documents\\S" + number + ".txt";

            
            using (StreamWriter write = File.CreateText(@"C:\Users\Public\Documents\S" + number + ".txt"))
            {
             JsonSerializer serializer = new JsonSerializer();
             serializer.Serialize(write, authors);
                    
                    
             }

            string query = "INSERT INTO Cases (C_Name,C_Authors_Path,C_Description) VALUES (@CaseName,@CAuthors,@CaseDesc)";

            using (SqlConnection myConnection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                myConnection.Open();

                cmd.Parameters.AddWithValue("@CaseName", caseName);
                cmd.Parameters.AddWithValue("@CAuthors", APath);
                cmd.Parameters.AddWithValue("@CaseDesc", caseDesc);

                cmd.ExecuteScalar();
                myConnection.Close();

                checker = true;

            }

            
            


            return checker;
        }

        public Boolean deleteCaseFromTable(String caseName) {
            Boolean checker = false;

            try
            {
                string query = "DELETE FROM Cases WHERE C_Name = @cName";

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query,myConnection))
                {

                    cmd.Parameters.AddWithValue("@cName", caseName);

                    myConnection.Open();
                    cmd.ExecuteScalar();
                    myConnection.Close();

                    checker = true;
                }


            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);

            }


            return checker;

        }

        public Case getCaseFromTable(String caseName) {
            Case potatoe = new Case();

            try
            {
                string query = "SELECT C_Name, C_Description, C_Authors_Path FROM Cases WHERE C_Name = @CaseName";

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {

                    Console.WriteLine(caseName);

                    cmd.Parameters.AddWithValue("@CaseName", caseName);
                    
                    myConnection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            potatoe.C_Name = reader["C_Name"].ToString();
                            potatoe.C_Desc = reader["C_Description"].ToString();
                            potatoe.pathAuthors = reader["C_Authors_Path"].ToString();

                        }
                        myConnection.Close();

                       

                    }
                }

                using (StreamReader r = new StreamReader(potatoe.pathAuthors))
                {
                    string json = r.ReadToEnd();
                    List<String> items = JsonConvert.DeserializeObject<List<String>>(json);
                    potatoe.C_Authors = items.ToList();
                }



            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);
            }

            return potatoe;
            

        }

        public int getCaseId(String cName) {
            int caseId = 0;

            try
            {

                string query = "SELECT Case_Id FROM Cases WHERE C_Name like @caseName";

                using (SqlConnection myConnection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {

                    cmd.Parameters.AddWithValue("@caseName", cName);

                    myConnection.Open();
                    caseId = (int) cmd.ExecuteScalar();
                    myConnection.Close();

                    

                }



            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);

            }

            return caseId;

        }

        public Boolean updateToTable(Case cName, String PrevName) {
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
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message);
            }


            return checker;

        }



    }
}
