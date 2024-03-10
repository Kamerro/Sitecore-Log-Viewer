using System;
using System.Xml.Serialization;

namespace LogViewer
{
    public class WindowProperties
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}