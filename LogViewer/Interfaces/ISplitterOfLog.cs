using System.Collections.Generic;

namespace LogViewer.Interfaces

{
    public interface ISplitterOfLog
    {
        List<string> SplitLogIntoPieces(string fileContent);
    }
}