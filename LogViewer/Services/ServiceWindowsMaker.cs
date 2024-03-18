using System;
using System.Collections.Generic;

namespace LogViewer
{
    public class ServiceWindowsMaker
    {
        public bool CreateNewWindow(string file, ConstantValues.StateMachine.TheStateOfTheSoftware state)
        {
            throw new NotImplementedException();
        }

        public bool InvokeNewWindow(string file, ConstantValues.StateMachine.TheStateOfTheSoftware state)
        {
            throw new NotImplementedException();
        }

        internal bool SetPropertiesOfTheWindow(WindowSettings parameters)
        {
            LogView view = new LogView(parameters);
            view.Show();
            return true;

        }
    }
}