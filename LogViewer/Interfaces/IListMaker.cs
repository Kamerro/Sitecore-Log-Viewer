using System.Collections.Generic;

namespace LogViewer.Interfaces

{
    public interface IListMaker
    {
        List<string> MakeListOfLogs(string[] splitedContent);
    } 
}