using System.Collections.Generic;

namespace LogViewer
{
    public interface IInternalListValidator
    {
        bool IsValidStringList(List<string> value);
    }
}