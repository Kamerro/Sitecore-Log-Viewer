using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LogViewer
{
    internal class ReadTheXmlFile:IInternalXMLFileReader
    {
        private List<KeyValuePair<string, string>> _keyValuePairs;

        public List<KeyValuePair<string, string>> ReadWindowProperties()
        {
            string filePath = ConstantValues.InternalConfiguration.WindowConfigLocalization;
            XDocument doc = XDocument.Load(filePath);
            foreach (XElement element in doc.Descendants())
            {

                var obj = element.Attributes().ToList();
                KeyValuePair<string, string> XElem = new KeyValuePair<string, string>(obj[0].Value, obj[1].Value);
                _keyValuePairs.Add(XElem);
            }

            return _keyValuePairs;

        }
    }
}