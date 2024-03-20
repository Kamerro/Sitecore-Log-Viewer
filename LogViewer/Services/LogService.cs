using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
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
        public int NumberOfMixedErrors;
        public int NumberOfSqlErrors;

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
            NumberOfMixedErrors = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("error"));
            NumberOfMixedErrors += splitedContent.Count(x => x.ToLower().Contains("info") && x.ToLower().Contains("error"));
            NumberOfMixedErrors += splitedContent.Count(x => x.ToLower().Contains("info") && x.ToLower().Contains("warn"));
            NumberOfSqlErrors += splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("warn"));
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
            string[] splitedContent = fileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            var listOfLogs = MakeListOfLogs(splitedContent);
            //FilterLinesWithExclude(splitedContent, exclude: "Commonly Used Types");
            listOfLogs = ExcludeNotUsefullLogs(listOfLogs);
            CheckParametersOfTheProvidedLog(listOfLogs.ToArray());
            return listOfLogs;
        }

        public List<string> SaveOnlySpecialType(string[] strings, List<string> listOfLogs)
        {
            List<string> listOfSpecialStrings = null;
            if (strings.Contains("warn") || strings.Contains("error"))
            {
                listOfSpecialStrings = new List<string>();
                for (int i = 0; i < listOfLogs.Count; i++)
                {
                    string hardlog = listOfLogs[i].Substring(0, listOfLogs[i].IndexOf("\r\n"));
               
                    if (hardlog.Contains(strings[0].ToUpper()))
                        listOfSpecialStrings.Add(listOfLogs[i]);
                    
                }
                strings[0] = String.Empty;
            }
            if (listOfSpecialStrings != null)
                return listOfSpecialStrings.Where(x => strings.All(str => x.ToLower().Contains(str.ToLower()))).ToList();


            return listOfLogs.Where(x => strings.All(str => x.ToLower().Contains(str.ToLower()))).ToList();
        }

        private List<string> MakeListOfLogs(string[] splitedContent)
        {
            StringBuilder sb = new StringBuilder();
            List<string> listOfLogs = new List<string>();
            foreach (string str in splitedContent)
            {
                if ((str.Length >= 3 && int.TryParse(str.Substring(0, 2), out int s) || str.IndexOf("ManagedPoolThread") == 0  || str.IndexOf("Rebus") == 0) && !String.IsNullOrEmpty(sb.ToString()))
                {
                    listOfLogs.Add(sb.ToString());
                    sb.Clear();
                    sb.AppendLine(str);
                }
                else
                {
                    sb.AppendLine(str);
                    if(!sb.ToString().Contains("\r\n"))
                        sb.AppendLine("\r\n");
                }
            }
            listOfLogs.Add(sb.ToString());
            return listOfLogs;
        }

        private List<string> ExcludeNotUsefullLogs(List<string> listOfLogs)
        {
            return listOfLogs?.Where(
                 str => ((str.Contains("ERROR"))
                 || (str.Contains("WARN") && !str.Contains("ManagedPoolThread"))
               //  || str.Contains("INFO")) && !str.Contains("ManagedPoolThread"))
                 )).ToList();
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

        internal List<string> WithExcluding(string[] strings, List<string> list)
        {
            //foreach(string str in list)
            //{
            //    foreach(string exclude in strings)
            //    {
            //        if (str.ToLower().Contains(exclude))
            //        {

            //        }
            //    }
            //}
            return list.Where(x => strings.All(str => !x.ToLower().Contains(str.ToLower()))).ToList();
        }
    }
}