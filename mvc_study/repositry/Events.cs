using mvc_study.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace mvc_study.repositry
{
    public class Events
    {
        public bool registerNewUser(RegisterModel datas)
        {
                Database.openConnection();
                SqlCommand sqlCommand = new SqlCommand("Register", Database.connection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@email", datas.email);
                sqlCommand.Parameters.AddWithValue("@name", datas.name);
                sqlCommand.Parameters.AddWithValue("@password", datas.password);
                sqlCommand.Parameters.AddWithValue("@usertype", "user");

                int res = sqlCommand.ExecuteNonQuery();
                Database.closeConnection();

                if (res > 0)
                {
                    return false;
                }
                else
                {
                return true;
                }
                
        }

        public DataTable loginUser(LoginModel loginModel)
        {
            Database.openConnection();
            SqlCommand sqlCommand  = new SqlCommand("Login",Database.connection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@email", loginModel.email);
            sqlCommand.Parameters.AddWithValue("@password", loginModel.password);
            SqlDataReader data = sqlCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(data);
            Database.closeConnection();
            return dt;
        }

        public List<DataModel> showData() {
            List<DataModel> dataList = new List<DataModel>();
            Database.openConnection();
            SqlCommand sqlCommand = new SqlCommand("showData", Database.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Database.closeConnection();
            foreach(DataRow rows in dt.Rows)
            {
                dataList.Add(new DataModel
                {
                id = Convert.ToInt32(rows["id"]),
                name = rows["name"].ToString(),
                email = rows["email"].ToString(),
                password = rows["password"].ToString(),
                userType = rows["usertype"].ToString(),
                });
            }
            return dataList;
        }

        public bool deleteUser(int id)
        {
            Database.openConnection();
            SqlCommand sqlCommand = new SqlCommand("deleteUser",Database.connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("id", id);
            int res = sqlCommand.ExecuteNonQuery();
            if(res == 0)
            {
                return false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"result =  {res}");
                return true;
            }
        }
    }
}