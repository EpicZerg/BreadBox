using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BreadBox
{
    class HTMLParser
    {
        private string OutputFilePath;
        private StreamReader defaultSiteReader;
        private StreamWriter outputWriter;
        public HTMLParser(string OutputFilePath)
        {
            this.OutputFilePath = OutputFilePath;
        }
        public void parseInfoToHTML(String boxName, String boxAuthor, String fileName, String fileAuthor, String timestamp, String ip){
            outputWriter = new StreamWriter(OutputFilePath);
            defaultSiteReader = new StreamReader("/content/defaultSite.html");
            defaultSiteReader.BaseStream.Position = 0;
            String defaultSite = defaultSiteReader.ReadToEnd();
            defaultSiteReader.Close();
            defaultSite = defaultSite.Replace("!_bxn", boxName);
            defaultSite = defaultSite.Replace("!_bxa", boxAuthor);
            defaultSite = defaultSite.Replace("!_fln", fileName);
            defaultSite = defaultSite.Replace("!_fla", fileAuthor);
            defaultSite = defaultSite.Replace("!_tstmp", timestamp);
            defaultSite = defaultSite.Replace("!_IP", ip);
            outputWriter.Write(defaultSite);
            outputWriter.Flush();
            outputWriter.Close();
        }
    }
}
