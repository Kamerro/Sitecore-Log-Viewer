using System.Collections.Generic;

namespace LogViewer.Interfaces

{
    public interface IHeadLogsChecker
    {
        List<string> CheckHeaderOfLog(string typeOfLog, List<string> listOfLogs);
    }
}