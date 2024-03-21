using System.Collections.Generic;

namespace LogViewer.Interfaces

{
    public interface ISaveSpecialLogs
    {
        List<string> SaveOnlySpecialType(string[] strings, List<string> listOfLogs);
    }
}