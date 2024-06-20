using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maneger_Right_project
{
    internal class DataAccess
    {
        public int InsertProduct(string connectionString)
        {
            string  productName, price, CategoryId, Description, ImageUrl;
         

            Console.WriteLine("insert productName");
            productName = Console.ReadLine();

            Console.WriteLine("insert price");
            price = Console.ReadLine();

            
            Console.WriteLine("insert Description");
            Description = Console.ReadLine();

            Console.WriteLine("insert ImageUrl");
            ImageUrl = Console.ReadLine().Trim();


            Console.WriteLine("insert CategoryId");
            CategoryId = Console.ReadLine();

            string query = "INSERT INTO Products( ProductName, price, Description, ImageUrl, CategoryId)" +
                "VALUES (@ProductName, @price, @Description, @ImageUrl, @CategoryId)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))

            {
                cmd.Parameters.Add("@ProductName", SqlDbType.NChar, 10).Value = productName;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@Description", SqlDbType.NChar, 50).Value = Description;
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NChar, 200).Value = ImageUrl;
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
                cn.Open();
                int RowAffected = cmd.ExecuteNonQuery();
                cn.Close();

                return RowAffected;
            }
        }
        public int InsertCategory(string connectionString)
        {

            string categoryName;


            Console.WriteLine("insert categoryName");
            categoryName = Console.ReadLine();



            string query = "INSERT INTO CATEGORIES(CategoryName) " +
            "VALUES(@CategoryName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryName", SqlDbType.NChar, 20).Value = categoryName;

                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();
                return rowAffected;
            }



        }
        internal void readProduct(string connectionString)
        {
            string queryString = "select * from Products";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                           reader[0], reader[1], reader[2]);

                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
        internal void readCategory(string connectionString)
        {
            string queryString = "select * from Categories";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}",
                           reader[0]);

                    }
                    reader.Close();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}


