using System;
using System.Collections.Generic;

namespace LogViewer
{
    internal class ServiceLogData
    {
        internal static void GenerateSeparatedLists(List<string> list,LogService logSplitter)
        {

            List<string> listErrorSolr = logSplitter.SaveOnlySpecialType(new string[] { "error", "solr" }, list);
            List<string> listErrorUnicorn = logSplitter.SaveOnlySpecialType(new string[] { "error", "unicorn" }, list);
            List<string> listWarnUnicorn = logSplitter.SaveOnlySpecialType(new string[] { "warn", "unicorn" }, list);

            List<string> listWarningsSolr = logSplitter.SaveOnlySpecialType(new string[] { "warn", "solr" }, list);
            List<string> listOfOtherWarns = logSplitter.WithExcluding(new string[] { "sql", "solr", "error", "unicorn" }, list);
            List<string> listErrorsSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql", "error" }, list);
            List<string> listWarnsSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql", "warn" }, list);

            Placeholder.List = list;
            Placeholder.ListErrorsSolr = listErrorSolr;
            Placeholder.ListErrorsUnicorn = listErrorUnicorn;
            Placeholder.ListWarningsUnicorn = listWarnUnicorn;
            Placeholder.ListWarningsSolr = listWarningsSolr;
            Placeholder.ListOfOtherWarns = listOfOtherWarns;
            Placeholder.ListErrorsSql = listErrorsSQL;
            Placeholder.ListWarningsSql = listWarnsSQL;
        }
    }
}