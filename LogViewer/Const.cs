using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogViewer
{
    public static class Const
    {
        public struct InternalConfiguration
        {
            public enum FileTypes
            {
                txt = 1,
                jpg = 2
            }
        }
        public struct StateMachine
        {
            public enum TheStateOfTheSoftware
            {
                Initial = 1,
                LoadedFile = 2,
                Advanced = 4,
                ClosingApplication = 8
            }
        }
     
        public static StateMachine.TheStateOfTheSoftware stateOfTheMachine = StateMachine.TheStateOfTheSoftware.Initial;
    }
}
