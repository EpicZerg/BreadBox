using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BreadBox
{
    class BoxHandler
    {
        DataBaseHandler dbh;
        public BoxHandler(DataBaseHandler dbh)
        {
            this.dbh = dbh;
        }
        public void createBox(String boxname, String username, String password)
        {
            if (Program.loggedIn)
            {
                dbh.newBox(boxname, username, password, Program.DB_BOX_TABLE);

                if (dbh.checkBox(boxname, username, Program.DB_BOX_TABLE))
                    Program.write("Box " + boxname + "successfully created.");
                else
                    Program.write("Error Box not created.");
            }
            else
                return;
        }
    }
        
}

