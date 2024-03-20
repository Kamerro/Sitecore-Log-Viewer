using System;
using System.Collections.Generic;
using System.Linq;

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

            List<string> listOfOtherLogs = logSplitter.WithExcluding(new string[] { "sql", "solr", "unicorn" }, list);

            List<string> listErrorsSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql", "error" }, list);

            List<string> listWarnsSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql", "warn" }, list);

            Placeholder.List = list;
            Placeholder.ListErrorsSolr = listErrorSolr;
            Placeholder.ListErrorsUnicorn = listErrorUnicorn;
            Placeholder.ListWarningsUnicorn = listWarnUnicorn;
            Placeholder.ListWarningsSolr = listWarningsSolr;
            Placeholder.ListOfOtherLogs = listOfOtherLogs;
            Placeholder.ListErrorsSql = listErrorsSQL;
            Placeholder.ListWarningsSql = listWarnsSQL;




            ////IM NOT PROUD OF THIS BUT THIS HELPED OUT TO FIND THE UNMATCHED LOGS !!!!!!!!!!!!!!!!
            // var listerinexD = ReturnDifferenceInLists();
        }

        ////IM NOT PROUD OF THIS BUT THIS HELPED OUT TO FIND THE UNMATCHED LOGS !!!!!!!!!!!!!!!!!!!!!!
        ///
        //private static List<string> returnMergedLists()
        //{
        //    return new List<string>().Concat(
        //        Placeholder.ListErrorsSolr.Concat(
        //            Placeholder.ListErrorsUnicorn.Concat(
        //                Placeholder.ListWarningsUnicorn.Concat(
        //                    Placeholder.ListWarningsSolr.Concat(
        //                        Placeholder.ListOfOtherLogs.Concat(
        //                            Placeholder.ListErrorsSql.Concat(
        //                                Placeholder.ListWarningsSql))))))).ToList();
        //}

        //public static List<string> ReturnDifferenceInLists()
        //{
        //    var list = returnMergedLists();
        //    return Placeholder.List.Where(x => !list.Contains(x)).ToList();
        //}

    }
}