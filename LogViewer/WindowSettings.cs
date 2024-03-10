using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogViewer
{
    [System.Xml.Serialization.XmlRootAttribute("WindowSettings", Namespace = "", IsNullable = false)]
    public class WindowSettings
    {
        [XmlElement(ElementName = "WindowProperties")]
        public WindowProperties[] Properties { get; set; }
    }
}
