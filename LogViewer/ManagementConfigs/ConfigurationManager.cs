using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LogViewer
{
    public class ConfigurationManager : IInternalListValidator
    {
        private static ConfigurationManager configurationManager = null;
        private ReadTheXmlFile _readTheXmlFile;
        private ConfigurationManager(ReadTheXmlFile xmlFileReader)
        {
            _readTheXmlFile = xmlFileReader;
        }
        public static ConfigurationManager TakeConfigurationManager()
        {
            if(configurationManager == null)
            {
                configurationManager = new ConfigurationManager(new ReadTheXmlFile());
            }
            return configurationManager;


        }
        public static void InitialConfigurationReadInternalConfig()
        {
            throw new NotImplementedException();
        }

        public bool IsValidStringList(List<string> value)
        {
            throw new NotImplementedException();
        }

        public WindowSettings ReturnPairedConfigurations(ConstantValues.InternalConfiguration.FileTypes fileType, bool LazyLoad)
        {

            WindowSettings settings = new WindowSettings();
            settings = _readTheXmlFile.ReadWindowProperties();
            return settings;

        }
    }
}
