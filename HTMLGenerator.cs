using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BreadBox
{
    class HTMLGenerator
    {
        private String OutputFilePath;
        private StreamReader defaultSiteReader;
        private StreamWriter outputWriter;
        public HTMLGenerator(String OutputFilePath)
        {
            this.OutputFilePath = OutputFilePath;
        }
        public void InfoToHTML(String boxName, String boxAuthor, String fileName, String fileAuthor, String timestamp, String ip, String baseurl, String rawContent){
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
            defaultSite = defaultSite.Replace("!_baseurl", baseurl);
            defaultSite = defaultSite.Replace("!_fileurl", baseurl + "content/" + fileName);
            defaultSite = defaultSite.Replace("!_userurl", baseurl + "user/" + fileAuthor);
            defaultSite = defaultSite.Replace("!_userimg", baseurl + "img/" + fileAuthor + ".png");
            defaultSite = defaultSite.Replace("!_raw_code", rawContent);
            defaultSite = defaultSite.Replace("!_IP", ip);
            outputWriter.Write(defaultSite);
            outputWriter.Flush();
            outputWriter.Close();
        }
        public void createUserSite(String username, String joindate, String userimageurl)
        {
            //todo
        }
    }
}

