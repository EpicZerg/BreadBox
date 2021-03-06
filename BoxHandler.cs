﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BBXBUILDER
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
                dbh.newBox(boxname, username, Program.DB_BOX_TABLE);

                if (dbh.checkBox(boxname, username, Program.DB_BOX_TABLE))
                    Program.write("Box " + boxname + "successfully created.");
                else
                    Program.write("Error Box not created.");
            }
            else
                return;
        }
        public void removeBox(String boxname, String username, String password)
        {
            if (Program.loggedIn)
            {
                dbh.removeBox(boxname, username, Program.DB_BOX_TABLE);

                if (!dbh.checkBox(boxname, username, Program.DB_BOX_TABLE))
                    Program.write("Box " + boxname + "successfully removed.");
                else
                    Program.write("Error Box not removed.");
            }
            else
                return;
        }
    }

}

