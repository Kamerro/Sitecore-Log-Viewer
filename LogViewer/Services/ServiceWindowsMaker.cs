using System;
using System.Collections.Generic;

namespace LogViewer
{
    public class ServiceWindowsMaker
    {
        internal bool SetPropertiesOfTheWindow(WindowSettings parameters)
        {
            LogView view = new LogView(parameters);
            view.Show();
            return true;

        }
    }
}