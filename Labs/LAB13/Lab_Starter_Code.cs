using System;
  
using System.Data.SqlClient;
 
namespace CS3500
{
    public class Lab_Starter_Code
    {
        /// <summary>
        /// The connection string.
        ///  </summary>
       public static readonly string connectionString;

        static Lab_Starter_Code()
        {

            connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "cs3500.eng.utah.edu", //host machine
                InitialCatalog = "cs3500", // database name
                UserID = "lab", // database username
                Password = "lab123456" // password for given user
            }.ConnectionString;
        }


        /// <summary>
        ///  Test several connections and print the output to the console
        /// </summary>
        /// <param name="args"></param>

        public static void Main(string[] args)
        {

            AllPatrons();

            Console.WriteLine("**......................***");
            PatronsPhones();

        }
        public static void AllPatrons()
        { 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {


                    con.Open();
                    
                    SqlCommand command =con.CreateCommand();
                    command.CommandText = "select * from Patrons";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["CardNum"] + " " + reader["Name"]);
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        public static void PatronsPhones()
        {
            // Connect to the DB
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    // Open a connection
                    conn.Open();

                    // Create a command
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "	SELECT Name,Phone FROM Patrons" +
                                          " JOIN Phones ON Patrons.CardNum = Phones.CardNum";

                    // Execute the command and cycle through the DataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["Name"] + " " + reader["Phone"]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


     }
}

