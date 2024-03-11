using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LogViewer.ConstantValues;
namespace LogViewer
{
    public delegate bool StateMachineWindow(string file, ConstantValues.StateMachine.TheStateOfTheSoftware state);
    public delegate bool ConfigDelegate(WindowSettings parameters);
    public partial class Form1 : Form
    {
        public event StateMachineWindow ChangeStateAndWindowHandler;
        public event ConfigDelegate OpenConfigWindowEvent;
        public Form1()
        {
            InitializeComponent();
         //   ConfigurationManager.InitialConfigurationReadInternalConfig();
            ServiceWindowsMaker maker  = new ServiceWindowsMaker();
              OpenConfigWindowEvent += maker.SetPropertiesOfTheWindow;
           // ChangeStateAndWindowHandler += maker.InvokeNewWindow;
          //  ChangeStateAndWindowHandler += maker.CreateNewWindow;
        }
        private void LoadLog_Click(object sender, EventArgs e)
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = ConstantValues.InternalConfiguration.LocalLogFolderLocalization;
            openFileDialog.Filter = ConstantValues.InternalConfiguration.LogFilterType;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                var openFile = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(openFile))
                {
                    ServiceChecker ServiceLogChecker = new ServiceChecker();
                    var fileContent = reader.ReadToEnd();
                    //ChangeStateAndWindowHandler.Invoke(fileContent,ConstantValues.StateMachine.TheStateOfTheSoftware.LoadedFile);
                    ServiceLogChecker.CheckParametersOfTheProvidedLog(fileContent);
                    ServiceLogChecker.SplitLogIntoPieces(fileContent);
                    LogViewerBox.AppendText("Number of lines: " + ServiceLogChecker.NumberOfTheLines.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of infos: " + ServiceLogChecker.NumberOfInfos.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of warns: " + ServiceLogChecker.NumberOfWarns.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of errors: " + ServiceLogChecker.NumberOfErrors.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of Solr errors: " + ServiceLogChecker.NumberOfSolrErrors.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of Solr warns: " + ServiceLogChecker.NumberOfSolrWarns.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of DI warns: " + ServiceLogChecker.NumberOfDIWarnings.ToString() + "\r\n");
                    LogViewerBox.AppendText(fileContent);

                }

            }
            OpenConfigWindowEvent.Invoke(ConstantValues.ConfigureWindowParameters);

        }
    }
}
