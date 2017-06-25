using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stathis.Data;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Stathis.Repository
{
    public class CustomerRepository
    {
        public List<Customer> GetCustomers()
        {
            //return listOfCustomers.  
            var customers = new List<Customer>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from Table2;";
                sqlCmd.Connection = connection;
                connection.Open();
                using (var reader = sqlCmd.ExecuteReader())
                {

                    while (reader.Read())
                    {

                        var customer = new Customer();
                        customer.Id = Int32.Parse(reader["Id"].ToString());
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Email = reader["Email"].ToString();
                        customers.Add(customer);

                    }
                }

            }

            return customers;
        }

        public Customer GetById(int Id)
        {
            var customer = new Customer();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from Table2 where Id='" + Id + "';";
                sqlCmd.Connection = connection;
                connection.Open();
                //SqlDataReader reader = sqlCmd.ExecuteReader();
                using (var reader = sqlCmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        customer.Id = Int32.Parse(reader["Id"].ToString());
                        customer.FirstName = reader["FirstName"].ToString();
                        customer.LastName = reader["LastName"].ToString();
                        customer.Email = reader["Email"].ToString();
                    }
                }
            }
            return customer;
        }

        public void Insert(Customer customer)
        {

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO Table2(FirstName,LastName,Email) VALUES(@FirstName,@LastName,@Email);";
                //  sqlCmd.Parameters.Add(new SqlParameter("@Id", customer.Id));
                sqlCmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                sqlCmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                sqlCmd.Parameters.Add(new SqlParameter("@Email", customer.Email));
                sqlCmd.Connection = connection;
                connection.Open();
                sqlCmd.ExecuteNonQuery();

            }

        }

    }
}
