using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LogViewer
{
    internal class ReadTheXmlFile : IInternalXMLFileReader
    {

        public WindowSettings ReadWindowProperties()
        {
            WindowSettings settings;
            using (TextReader reader = new StreamReader(ConstantValues.InternalConfiguration.WindowConfigLocalization))
            {
                XmlSerializer ser = new XmlSerializer(typeof(WindowSettings));
                settings = (WindowSettings)ser.Deserialize(reader);
            }
            return settings;
        }
    }
}