using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreadBox
{
    class Program
    {
        static String INFO = "BreadBox\n=======\n\nOpen Source.\nhttps://github.com/EpicZerg/BreadBox\n=========================================";
        static String HELP_A = "Commands:\ninfo : Displays Information\nhelp : Displays this\nlogin username password : Logs you in for the current Session\n";
        static String HELP_B = "";
        static String DB_USER_TABLE = "LoginCredentials";
        static String DB_HOST = "", DB_USER = "", DB_PASS = "", DB_DATABASE = "";
        static Boolean loggedIn = false;
        static void Main(string[] args)
        {
            
            if (args.Length != 0)
            {
                DataBaseHandler dbh = new DataBaseHandler();
                dbh.connect(DB_HOST, DB_USER, DB_PASS, DB_DATABASE);
                switch (args[0])
                {
                    case "info":
                        {
                            write(INFO);
                            break;
                        }
                    case "help":
                        {
                            write(HELP_A + HELP_B);
                            break;
                        }
                    case "login":
                        {
                            if (args.Length > 2)
                                if (dbh.login(args[1], args[2], DB_USER_TABLE))
                                    loggedIn = true;
                                else
                                    write("Login wrong, or DB is down.");
                            break;
                        }
                    default:
                        {
                            write(HELP_A + HELP_B);
                            break;
                        }
                   }
            }
        }
        static void write(String s)
        {
            Console.Out.Write(s);
        }
    }
}