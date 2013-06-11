using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreadBox
{
    class Program
    {
        static String INFO = "BreadBox\n=======\n\nOpen Source.\nhttps://github.com/EpicZerg/BreadBox\n=========================================";
        static String HELP = "";
        static void Main(string[] args)
        {
            
            if (args.Length != 0)
            {
                DataBaseHandler dbh = new DataBaseHandler();
                dbh.connect("HOST", "USER", "PASSWORD");
                switch (args[0])
                {
                    case "info":
                        {
                            write(INFO);
                            break;
                        }
                    case "help":
                        {
                            write(HELP);
                            break;
                        }
                    case "permlogin":
                        {
                            if (args.Length > 2)
                                dbh.login(args[1], args[2]);
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
