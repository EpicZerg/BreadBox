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
        internal void connect(String host, String user, String password, String database){
            DataBaseConnection = new SqlConnection("user id="+ user + ";password="+ password + ";server=" + host + ";Trusted_Connection=yes;" + "database=" + database + ";connection timeout=60");
            try
            {
                DataBaseConnection.Open();
            }
            catch
            {
                Program.write("Error, couldn't connect to Database");
                return;
            }
            isInit = true;
        }
        internal Boolean login(String username, String password, String table)
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
        internal void newBox(String boxname, String username, String table)
        {
            if (isInit)
                using (SqlCommand StrQuer = new SqlCommand("INSERT INTO @table VALUES (@boxname,@username);", DataBaseConnection))
                {
                    StrQuer.Parameters.AddWithValue("@table", table);
                    StrQuer.Parameters.AddWithValue("@boxname", boxname);
                    StrQuer.Parameters.AddWithValue("@username", username);
                    StrQuer.ExecuteReader();
                }
            else
                return false;
        }
        internal Boolean checkBox(String boxname, String username, String table)
        {
            if (isInit)
                using (SqlCommand StrQuer = new SqlCommand("SELECT * FROM @table WHERE boxname=@boxname AND username=@username", DataBaseConnection))
                {
                    StrQuer.Parameters.AddWithValue("@table", table);
                    StrQuer.Parameters.AddWithValue("@username", username);
                    StrQuer.Parameters.AddWithValue("@boxname",boxname);
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

