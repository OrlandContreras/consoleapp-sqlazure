using System;
using System.Data;
using System.Data.SqlClient;



namespace mySqlAzure
{    
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            try
            {
                // Build connection string ADO.NET
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "your_server.database.windows.net";
                builder.UserID = "your_server";
                builder.Password = "your_password";
                builder.InitialCatalog = "adventureWorks"; // Base de datos de ejemplo Adventure Works (sql azure)

                Console.WriteLine("Ingresa el código del producto: ");
                product.ProductID = int.Parse(Console.ReadLine());
                
                // Connection String ADO.NET
                // String stringConnection = "Server=tcp:{your_server}.database.windows.net,1433;Initial Catalog={your_database};Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

                using (SqlConnection connection  =  new SqlConnection(builder.ConnectionString)) // stringConnection
                {
                    using (SqlCommand command = new SqlCommand("SalesLT.getProductById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@ProductID", SqlDbType.Int));
                        command.Parameters["@ProductID"].Value = product.ProductID;                      

                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                             // product.ProductID = (int)reader["ProductID"];
                             product.Name = reader["Name"].ToString();
                             product.ProductNumber = reader["ProductNumber"].ToString();
                             product.Color = reader["Color"].ToString();
                             product.StandardCost = (decimal)reader["StandardCost"];
                             product.ListPrice = (decimal)reader["ListPrice"];
                             product.Size = reader["Size"].ToString();
                             product.Weight = (reader["Weight"] == DBNull.Value) ? decimal.Zero : (decimal)reader["Weight"];
                            }
                            Console.WriteLine("============== Información del producto ======================");
                            Console.WriteLine("ProductID: {0}\nName: {1}\nProduct Number: {2}\nColor: {3}\nStardard Cost: {4}\nList Price: {5}\nSize: {6}\nWeight: {7}",
                                                product.ProductID,
                                                product.Name,
                                                product.ProductNumber,
                                                product.Color,
                                                product.StandardCost,
                                                product.ListPrice,
                                                product.Size,
                                                product.Weight);
                        }
                        catch (SqlException sqlex)
                        {
                            Console.WriteLine(sqlex);
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

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
