using System.Collections.Generic;

namespace LogViewer.Interfaces

{
    public interface IExcluderOfLogs
    {
        List<string> ExcludeNotUsefullLogs(List<string> listOfLogs);
        List<string> WithExcluding(string[] strings, List<string> list);
    }
}