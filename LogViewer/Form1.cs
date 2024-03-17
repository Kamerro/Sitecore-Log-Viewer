using System;
using System.CodeDom.Compiler;
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
            ServiceWindowsMaker maker = new ServiceWindowsMaker();
            OpenConfigWindowEvent += maker.SetPropertiesOfTheWindow;
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
                string fileContent;
                LogService logSplitter = new LogService();
                using (StreamReader reader = new StreamReader(openFile))
                {
                    fileContent = reader.ReadToEnd();
                }
                GenerateListsOfLogs(fileContent, logSplitter);
            }
            OpenConfigWindowEvent.Invoke(ConstantValues.ConfigureWindowParameters);

        }

        private void GenerateListsOfLogs(string fileContent, LogService logSplitter)
        {
            //ChangeStateAndWindowHandler.Invoke(fileContent,ConstantValues.StateMachine.TheStateOfTheSoftware.LoadedFile);
            List<string> list = logSplitter.SplitLogIntoPieces(fileContent);
            List<string> listErrorSolr = logSplitter.SaveOnlySpecialType(new string[] { "error", "solr" }, list);
            List<string> listErrorUnicorn = logSplitter.SaveOnlySpecialType(new string[] { "error", "unicorn" }, list);
            List<string> listWarnUnicorn = logSplitter.SaveOnlySpecialType(new string[] { "warn", "unicorn" }, list);

            List<string> listWarningsSolr = logSplitter.SaveOnlySpecialType(new string[] { "warn", "solr" }, list);
            List<string> listOfOtherWarns = logSplitter.WithExcluding(new string[] { "sql", "solr", "error","unicorn"}, list);
            List<string> listSQL = logSplitter.SaveOnlySpecialType(new string[] { "sql" }, list);

          
            Placeholder.List = list;
            Placeholder.ListErrorSolr = listErrorSolr;
            Placeholder.ListErrorUnicorn = listErrorUnicorn;
            Placeholder.ListWarnUnicorn = listWarnUnicorn;
            Placeholder.ListWarningsSolr = listWarningsSolr;
            Placeholder.ListOfOtherWarns = listOfOtherWarns;
            Placeholder.ListSQL = listSQL;
            LogViewerBox.AppendText("Number of other warns " + listOfOtherWarns.Count + "\r\n");

            LogViewerBox.AppendText("Number of errors from solr: " + listErrorSolr.Count + "\r\n");
            LogViewerBox.AppendText("Number of warns from solr: " + listWarningsSolr.Count + "\r\n");
            LogViewerBox.AppendText("Number of SQL logs: " + listSQL.Count + "\r\n");
            LogViewerBox.AppendText("Number of Unicorn warns: " + listWarnUnicorn.Count + "\r\n");
            LogViewerBox.AppendText("Number of Unicorn errors: " + listErrorUnicorn.Count + "\r\n");
        }
    }
}
