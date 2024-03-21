namespace LogViewer.Interfaces

{
    public interface IInfoLogs
    {
       void CheckParametersOfTheProvidedLog(string fileContent);
       void CheckParametersOfTheProvidedLog(string[] splitedContent);
         int NumberOfTheLines { get; set; }
         int NumberOfErrors { get; set; }
         int NumberOfSolrErrors { get; set; }
         int NumberOfSolrWarns { get; set; }
         int NumberOfWarns { get; set; }
         int NumberOfInfos { get; set; }
         int NumberOfDIWarnings { get; set; }
         int NumberOfMixedErrors { get; set; }
         int NumberOfSqlErrors { get; set; }
    }
}