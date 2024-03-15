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
                    List<string> list = logSplitter.SplitLogIntoPieces(fileContent);
                    List<string> listErrorSolr = logSplitter.SaveOnlySpecialType(new string[] { "error", "solr" }, list);
                    List<string> listWarningsSolr = logSplitter.SaveOnlySpecialType(new string[] { "warn", "solr" }, list);
                    List<string> listSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql" }, list);

                    LogViewerBox.AppendText("Number of errors from solr: " + listErrorSolr.Count + "\r\n");
                    LogViewerBox.AppendText("Number of warns from solr: " + listWarningsSolr.Count + "\r\n");
                    LogViewerBox.AppendText("Number of SQL logs: " + listSQL.Count + "\r\n");

                    //LogViewerBox.AppendText(list.Where(x => x.ToLower().Contains("error") && x.ToLower().Contains("solr")).First());
                    //foreach (var line in list)
                    //{
                    //    LogViewerBox.AppendText(line + "\r");
                    //}
                }
            }
            OpenConfigWindowEvent.Invoke(ConstantValues.ConfigureWindowParameters);

        }
    }
}
