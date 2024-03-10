using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogViewer.ConstantValues.InternalConfiguration;

namespace LogViewer
{
    public static class ConstantValues
    {
        public static WindowSettings ConfigureWindowParameters =
                          ConfigurationManager.TakeConfigurationManager()
                          .ReturnPairedConfigurations(FileTypes.txt, false);
        public struct InternalConfiguration
        {

          
            public static string WindowConfigLocalization = AppDomain.CurrentDomain.BaseDirectory.ToString() + "WindowConfiguration.xml";
            public const string LocalLogFolderLocalization= @"C:\LogFileExample";
            public const string LogFilterType = "txt files (*.txt)|*.txt";

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
