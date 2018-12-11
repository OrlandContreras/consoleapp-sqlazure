using System;
using System.Data.SqlClient;

namespace mySqlAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Build connection string ADO.NET
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "your_server.database.windows.net";
                builder.UserID = "your_user";
                builder.Password = "your_password";
                builder.InitialCatalog = "your_database";
                
                // Connection String ADO.NET
                // String stringConnection = "Server=tcp:{your_server}.database.windows.net,1433;Initial Catalog={your_database};Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection  =  new SqlConnection(builder.ConnectionString)) // stringConnection
                {
                    connection.Open();
                    Console.WriteLine("Status connection: " + connection.State.ToString());
                }
            }
            catch (SqlException exsql)
            {
                
                Console.WriteLine(exsql.ToString());
            }
            //Console.WriteLine("Hello World!");
        }
    }
}
