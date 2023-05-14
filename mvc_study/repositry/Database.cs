using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvc_study.repositry
{
    public class Database
    {
        public static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public static void openConnection()
        {
           if(connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}