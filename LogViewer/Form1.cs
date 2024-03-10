using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LogViewer.Const;

namespace LogViewer
{
    public delegate bool StateMachineDelegate(string file, TheStateOfTheSoftware state);
    public delegate bool ConfigDelegate(string[] parameters);
    public partial class Form1 : Form
    {
        public event StateMachineDelegate ChangeStateOfMachineEvent;
        public event ConfigDelegate OpenConfigWindowEvent;
        public Form1()
        {
            InitializeComponent();
            ConfigurationManager.InitialConfigurationReadInternalConfig();
            ServiceWindowsMaker maker  = new ServiceWindowsMaker();
            ChangeStateOfMachineEvent += maker.InvokeNewWindow;
            ChangeStateOfMachineEvent += maker.CreateNewWindow;
        }
        private void LoadLog_Click(object sender, EventArgs e)
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\LogFileExample";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                var openFile = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(openFile))
                {
                    var fileContent = reader.ReadToEnd();
                    ChangeStateOfMachineEvent.Invoke(fileContent,TheStateOfTheSoftware.LoadedFile);
                    OpenConfigWindowEvent.Invoke(Const.ConfigureWindowParameters);

                }
            }
        }
    }
}
