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
        internal static String DB_USER_TABLE = "LoginCredentials", DB_BOX_TABLE = "Boxes"; //Needs to be Defined!
        internal static String DB_HOST = "", DB_USER = "", DB_PASS = "", DB_DATABASE = "";//Needs to be Defined!
        public static Boolean loggedIn = false;
        public static String homeurl = "http://am.d.gp/";//Needs to be Defined!
        internal static DataBaseHandler dbh = new DataBaseHandler();
        private static String loggedInUsername = "", loggedInPassword = "";
        static HTMLParser htmlp = new HTMLParser("/content/temp.html");
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {                
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
                            if (args.Length == 2)
                                if (dbh.login(args[1], args[2], DB_USER_TABLE)){
                                    loggedIn = true;
                                    loggedInUsername = args[1];
                                    loggedInPassword = args[2];
                                }
                                else
                                    write("Login wrong, or DB is down.");
                            else
                                write("Wrong Arguments\n" + HELP_A + HELP_B);
                            break;
                        }
                    case "box":
                        {
                            if (args.Length < 3)
                            {
                                write("Wrong Arguments\n" + HELP_A + HELP_B);
                                break;
                            }
                            else
                            {
                                BoxHandler box = new BoxHandler(dbh);
                                if(args[1].StartsWith("cr")){
                                    if(args[2].Contains("\"") || args[2].Contains("§") || args[2].Contains("$") || args[2].Contains("%") || args[2].Contains("&") || args[2].Contains("?") || args[2].Contains("`") || args[2].Contains("´") || args[2].Contains("'") || args[2].Contains("~")){
                                        write("Invalid Boxname, Allowed Letters: abcdefghijklmnopqrstuvwxyz1234567890#*+!-_.,[SPACE]");
                                        break;
                                    }
                                    else
                                        box.newBox(args[2].Replace(" ","_"), loggedInUsername, DB_BOX_TABLE);
                                }
                                else if (args[1].StartsWith("cr"))
                                {
                                    if(box.checkBox(args[2].Replace(" ","_"), loggedInUsername, DB_BOX_TABLE)){
                                        box.removeBox(args[2].Replace(" ", "_"), loggedInUsername, DB_BOX_TABLE);
                                    }
                                }
                            }
                                break;
                        }
                    default:
                        {
                            write("Not a valid Function\n" + HELP_A + HELP_B);
                            break;
                        }
                   }
            }
            Console.In.Read(); //For not instantly Exiting.
            dbh.disconnect();
        }
        static void write(String s)
        {
            Console.Out.Write(s);
        }
    }
}
