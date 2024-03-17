using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class CustomAttribute : Attribute
    {
        public int MyProperty { get; set; }
        public CustomAttribute(int prop)
        {
            MyProperty = prop;
        }

    }

    [Custom(3)]
    internal class Weirdo
    {
        public Weirdo obj = new Weirdo();
        public int ReturnAttributeValue()
        {
            var classAttributes = typeof(Weirdo).GetCustomAttributes(typeof(CustomAttribute), false);
            foreach (CustomAttribute cust in classAttributes)
            {
                return cust.MyProperty;
            }
            return -1 ;
        }
    }

}
