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

            string[] splitedContent = fileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            NumberOfTheLines = splitedContent.Length;
            NumberOfInfos = splitedContent.Count(x => x.ToLower().Contains("info"));
            NumberOfWarns = splitedContent.Count(x => x.ToLower().Contains("warn"));
            NumberOfErrors = splitedContent.Count(x => x.ToLower().Contains("error"));
            NumberOfSolrErrors = splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("solr"));
            NumberOfSolrWarns = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("solr"));
            NumberOfDIWarnings = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("constructor"));
        }
        public void CheckParametersOfTheProvidedLog(string[] splitedContent)
        {
            NumberOfTheLines = splitedContent.Length;
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
            int beforeExclude = splitedContent.Where(x=>!String.IsNullOrEmpty(x)).Count();
            List<string> listOfLogs = new List<string>();
            //FilterLinesWithExclude(splitedContent, exclude: "Commonly Used Types");
            int afterExclude = splitedContent.Where(x => !String.IsNullOrEmpty(x)).Count();
            foreach (string str in splitedContent)
            {
                if ((str.Length >= 3 && int.TryParse(str.Substring(0, 2), out int s) || str.IndexOf("ManagedPoolThread") == 0) && !String.IsNullOrEmpty(sb.ToString()))
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


            listOfLogs = listOfLogs.Where(
                str => ((str.Contains("ERROR"))
                || (str.Contains("WARN") && !str.Contains("ManagedPoolThread"))
                || str.Contains("INFO") && !str.Contains("ManagedPoolThread"))).ToList();

            return listOfLogs;
        }

        private void FilterLinesWithExclude(string[] splitedContent, string exclude)
        {
            bool ExcldudeLine = false;
            int i = 0;
            foreach (string str in splitedContent)
            {
                
                if (str.StartsWith(exclude))
                    ExcldudeLine = true;

                else if (String.IsNullOrEmpty(str.Trim()) || str.Equals("\t"))
                   ExcldudeLine = false;

                if (ExcldudeLine)
                    splitedContent[i] = "";

                i++;
            }
        }
    }
}