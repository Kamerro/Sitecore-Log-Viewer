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
          //sdsfdfghfhgfhffgfgfhgfhgf
          //sfsddsgggg
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
                    LogService logSplitter = new LogService();
                    var fileContent = reader.ReadToEnd();
                    //ChangeStateAndWindowHandler.Invoke(fileContent,ConstantValues.StateMachine.TheStateOfTheSoftware.LoadedFile);
                    logSplitter.CheckParametersOfTheProvidedLog(fileContent);
                    List<string> list = logSplitter.SplitLogIntoPieces(fileContent);
                    LogViewerBox.AppendText("Number of lines: " + logSplitter.NumberOfTheLines.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of infos: " + logSplitter.NumberOfInfos.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of warns: " + logSplitter.NumberOfWarns.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of errors: " + logSplitter.NumberOfErrors.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of Solr errors: " + logSplitter.NumberOfSolrErrors.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of Solr warns: " + logSplitter.NumberOfSolrWarns.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of DI warns: " + logSplitter.NumberOfDIWarnings.ToString() + "\r\n");
                    LogViewerBox.AppendText("Number of usefull logs: " + list.Count + "\r\n");
                    LogViewerBox.AppendText(fileContent);

                }
            }
            OpenConfigWindowEvent.Invoke(ConstantValues.ConfigureWindowParameters);

        }
    }
}
