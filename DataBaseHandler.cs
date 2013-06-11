using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BreadBox
{
    class DataBaseHandler
    {
        Boolean isInit = false;
        SqlConnection DataBaseConnection;
        internal void connect(string host, string user, string password, string database){
            DataBaseConnection = new SqlConnection("user id="+ user + ";password="+ password + ";server=" + host + ";Trusted_Connection=yes;" + "database=" + database + ";connection timeout=30");
            DataBaseConnection.Open();
            //todo Try and Catch
            isInit = true;
        }
        internal Boolean login(string username, string password, string table)
        {
            if (isInit)
                using (SqlCommand StrQuer = new SqlCommand("SELECT * FROM @table WHERE username=@username AND password=@password", DataBaseConnection))
                {
                    StrQuer.Parameters.AddWithValue("@table", table);
                    StrQuer.Parameters.AddWithValue("@username", username);
                    StrQuer.Parameters.AddWithValue("@password", password);
                    SqlDataReader dr = StrQuer.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            else
                return false;
        }
        internal void disconnect()
        {
            if(isInit)
            DataBaseConnection.Close();
        }
    }
}

