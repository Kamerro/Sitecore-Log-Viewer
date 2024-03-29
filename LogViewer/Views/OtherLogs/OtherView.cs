﻿using LogViewer.Configurations;
using LogViewer.Solr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer.Views.OtherLogs
{
    public partial class OtherView : Form
    {
        public OtherView()
        {
            InitializeComponent();
        }

        private void AcceptCOnfigurationButton_Click(object sender, EventArgs e)
        {

            OtherLogsConfigurations.Warns = checkBoxAcceptWarns.Checked;
            OtherLogsConfigurations.Errors = checkBoxIncludeErrors.Checked;
            OtherLogsConfigurations.Sentence1 = IncludeText.Text;
            OtherLogsConfigurations.Sentence2 = Include_2Text.Text;
            this.Close();
        }
    }
}
