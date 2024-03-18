using System.Collections.Generic;

namespace LogViewer
{
    public interface IInternalXMLFileReader
    {
        WindowSettings ReadWindowProperties();
    }
}