using System;
using System.Collections.Generic;

namespace LogViewer
{
    public class ConfigurationManager:IConfugurationManager
    {
        public static void InitialConfigurationReadInternalConfig()
        {
            throw new NotImplementedException();
        }

        public bool IsValidStringList(List<string> value)
        {
            throw new NotImplementedException();
        }

        public string ReadFile(Const.InternalConfiguration.FileTypes fileTpe, bool LazyLoad)
        {
            throw new NotImplementedException();
        }
    }
}