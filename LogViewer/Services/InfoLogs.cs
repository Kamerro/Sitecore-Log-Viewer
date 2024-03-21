using System.Linq;
using System;

namespace LogViewer
{
    public class InfoLogs : IInfoLogs
    {
        private int _numberOfTheLines;
        private int _numberOfErrors;
        private int _numberOfSolrErrors;
        private int _numberOfSolrWarns;
        private int _numberOfWarns;
        private int _numberOfInfos;
        private int _numberOfDIWarnings;
        private int _numberOfMixedErrors;
        private int _numberOfSqlErrors;

        public int NumberOfTheLines
        {
            get => _numberOfTheLines;
            set
            {
                if (value is 0)
                {
                    throw new Exception("Empty Log file.");
                }
                _numberOfTheLines = value;
            }
        }
        public int NumberOfErrors
        {
            get => _numberOfErrors;
            set => _numberOfErrors = value;
        }
        public int NumberOfSolrErrors
        {
            get => _numberOfSolrErrors;
            set => _numberOfSolrErrors = value;
        }
        public int NumberOfSolrWarns
        {
            get => _numberOfSolrWarns;
            set => _numberOfSolrWarns = value;
        }
        public int NumberOfWarns
        {
            get => _numberOfWarns;
            set => _numberOfWarns = value;
        }
        public int NumberOfInfos
        {
            get => _numberOfInfos;
            set => _numberOfInfos = value;
        }
        public int NumberOfDIWarnings
        {
            get => _numberOfDIWarnings;
            set => _numberOfDIWarnings = value;
        }
        public int NumberOfMixedErrors
        {
            get => _numberOfMixedErrors;
            set => _numberOfMixedErrors = value;
        }
        public int NumberOfSqlErrors
        {
            get => _numberOfSqlErrors;
            set => _numberOfSqlErrors = value;
        }

        public void CheckParametersOfTheProvidedLog(string fileContent)
        {

            string[] splitedContent = fileContent.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            _numberOfTheLines = splitedContent.Length;
            _numberOfInfos = splitedContent.Count(x => x.ToLower().Contains("info"));
            _numberOfWarns = splitedContent.Count(x => x.ToLower().Contains("warn"));
            _numberOfErrors = splitedContent.Count(x => x.ToLower().Contains("error"));
            _numberOfSolrErrors = splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("solr"));
            _numberOfSolrWarns = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("solr"));
            _numberOfDIWarnings = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("constructor"));
            _numberOfMixedErrors = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("error"));
            _numberOfMixedErrors += splitedContent.Count(x => x.ToLower().Contains("info") && x.ToLower().Contains("error"));
            _numberOfMixedErrors += splitedContent.Count(x => x.ToLower().Contains("info") && x.ToLower().Contains("warn"));
            _numberOfSqlErrors += splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("warn"));
        }
        public void CheckParametersOfTheProvidedLog(string[] splitedContent)
        {
            _numberOfTheLines = splitedContent.Length;
            _numberOfInfos = splitedContent.Count(x => x.ToLower().Contains("info"));
            _numberOfWarns = splitedContent.Count(x => x.ToLower().Contains("warn"));
            _numberOfErrors = splitedContent.Count(x => x.ToLower().Contains("error"));
            _numberOfSolrErrors = splitedContent.Count(x => x.ToLower().Contains("error") && x.ToLower().Contains("solr"));
            _numberOfSolrWarns = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("solr"));
            _numberOfDIWarnings = splitedContent.Count(x => x.ToLower().Contains("warn") && x.ToLower().Contains("constructor"));
        }

    }
}