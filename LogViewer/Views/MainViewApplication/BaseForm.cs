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
    public partial class BaseForm : Form
    {
        public event StateMachineWindow ChangeStateAndWindowHandler;
        public event ConfigDelegate OpenConfigWindowEvent;
        public BaseForm()
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
            LogService logSplitter = new LogService();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                var openFile = openFileDialog.OpenFile();
                string fileContent;
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
            List<string> list = logSplitter.SplitLogIntoPieces(fileContent);
            ServiceLogData.GenerateSeparatedLists(list,logSplitter);

        }
    }
}
