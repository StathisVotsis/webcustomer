﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stathis.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Stathis.Repository
{
    public class UserRepository
    {
        public User GetByPass(string name,string pass)
        {
            var user = new User();
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ToString()))
            {

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "Select * from Table3 where UserName='" + name + "' AND PassWord='"+ pass +"';";
                sqlCmd.Connection = connection;
                connection.Open();
                //SqlDataReader reader = sqlCmd.ExecuteReader();
                using (var reader = sqlCmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        user.Id = Int32.Parse(reader["Id"].ToString());
                        user.UserName = reader["UserName"].ToString();
                        user.Password = reader["PassWord"].ToString();
                        
                    }
                }
            }
            
            return user;
        }
    }
}
