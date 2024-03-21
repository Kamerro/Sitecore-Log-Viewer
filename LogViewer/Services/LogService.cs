using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;

namespace LogViewer
{
    public class LogService:InfoLogs
    {
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
                listOfSpecialStrings = CheckHeaderOfLog(strings[0], listOfLogs);
                strings[0] = String.Empty;
                return listOfSpecialStrings.Where(x => strings.All(str => x.ToLower().Contains(str.ToLower()))).ToList();
            }

            return listOfLogs.Where(x => strings.All(str => x.ToLower().Contains(str.ToLower()))).ToList();
        }

        private List<string> CheckHeaderOfLog(string typeOfLog, List<string> listOfLogs)
        {
            return listOfLogs.Where(x => x.Substring(0, x.IndexOf("\r\n")).Contains(typeOfLog.ToUpper())).ToList();
        }

        private List<string> MakeListOfLogs(string[] splitedContent)
        {
            StringBuilder sb = new StringBuilder();
            List<string> listOfLogs = new List<string>();
            foreach (string str in splitedContent)
            {
                if ((str.Length >= 3 && int.TryParse(str.Substring(0, 2), out int s) || str.IndexOf("ManagedPoolThread") == 0 || str.IndexOf("Rebus") == 0) && !String.IsNullOrEmpty(sb.ToString()))
                {
                    listOfLogs.Add(sb.ToString());
                    sb.Clear();
                    sb.AppendLine(str);
                }
                else
                {
                    sb.AppendLine(str);
                    if (!sb.ToString().Contains("\r\n"))
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
            return list.Where(x => strings.All(str => !x.ToLower().Contains(str.ToLower()))).ToList();
        }
    }
}