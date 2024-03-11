using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogViewer
{
    public class LogService
    {
        public int NumberOfTheLines;
        public int NumberOfErrors;
        public int NumberOfSolrErrors;
        public int NumberOfSolrWarns;
        public int NumberOfWarns;
        public int NumberOfInfos;
        public int NumberOfDIWarnings;


        public void CheckParametersOfTheProvidedLog(string fileContent)
        {
            string[] splitedContent = fileContent.Split(new string[] { "\r\n","\n" }, StringSplitOptions.None);
            int i = 0;
            foreach(string str in splitedContent)
            {
                if(str.Length>=3 && int.TryParse(str.Substring(0,2),out int s))
                {
                    i++;
                }
            }
            NumberOfTheLines = i;//splitedContent.Length;
            NumberOfInfos = splitedContent.Count(x => x.ToLower().Contains("info"));
            NumberOfWarns = splitedContent.Count(x => x.ToLower().Contains("warn"));
            NumberOfErrors = splitedContent.Count(x => x.ToLower().Contains("error"));
            NumberOfSolrErrors = splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("solr"));
            NumberOfSolrWarns = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("solr"));
            NumberOfDIWarnings = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("constructor"));
        }

        public List<string> SplitLogIntoPieces(string fileContent)
        {
            StringBuilder sb = new StringBuilder();
            string[] splitedContent = fileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string singleLog = String.Empty;
            List<string> listOfLogs = new List<string>();
            foreach (string str in splitedContent)
            {
                if ((str.Length >= 3 && int.TryParse(str.Substring(0, 2), out int s) || str.IndexOf("ManagedPoolThread")==0)&&!String.IsNullOrEmpty(sb.ToString()))
                {
                    listOfLogs.Add(sb.ToString());
                    sb.Clear();
                    sb.AppendLine(str);
                }
                else
                {
                    sb.AppendLine(str);
                }
            }
            listOfLogs.Add(sb.ToString());

            return listOfLogs;
        }
    }
}