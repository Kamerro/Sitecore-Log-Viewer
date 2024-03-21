using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using LogViewer.Interfaces;
namespace LogViewer
{
    public class LogService:InfoLogs,ISplitterOfLog,ISaveSpecialLogs,IHeadLogsChecker,IListMaker,IExcluderOfLogs
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

        public List<string> CheckHeaderOfLog(string typeOfLog, List<string> listOfLogs)
        {
            return listOfLogs.Where(x => x.Substring(0, x.IndexOf("\r\n")).Contains(typeOfLog.ToUpper())).ToList();
        }

        public List<string> MakeListOfLogs(string[] splitedContent)
        {
           
            StringBuilder sb = new StringBuilder();
            List<string> listOfLogs = new List<string>();
            foreach (string str in splitedContent)
            {
                //Should be written constants where the parameters should be defined, also this should be wrapped into service, the simplification will be great (readability probably will be worse but easier to maintain.)
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

        public List<string> ExcludeNotUsefullLogs(List<string> listOfLogs)
        {
            //instead of magic strings there would be constants, for every constant log list should be extended!
            //to consider while work.
            return listOfLogs?.Where(
                 str => ((str.Contains("ERROR"))
                 || (str.Contains("WARN") && !str.Contains("ManagedPoolThread"))
                 //  || str.Contains("INFO")) && !str.Contains("ManagedPoolThread"))
                 )).ToList();
        }

   
        public List<string> WithExcluding(string[] strings, List<string> list)
        {
            return list.Where(x => strings.All(str => !x.ToLower().Contains(str.ToLower()))).ToList();
        }
    }
}