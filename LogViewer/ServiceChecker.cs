using System;
using System.Linq;

namespace LogViewer
{
    public class ServiceChecker
    {
        public void CheckParametersOfTheProvidedLog(string fileContent)
        {
            string[] splitedContent = fileContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            int count = splitedContent.Length;
        }
    }
}