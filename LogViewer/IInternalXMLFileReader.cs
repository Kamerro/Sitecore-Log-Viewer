using System.Collections.Generic;

namespace LogViewer
{
    public interface IInternalXMLFileReader
    {
        List<KeyValuePair<string,string>> ReadWindowProperties();
    }
}