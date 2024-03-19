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
using LogViewer.Sql;
using LogViewer.Configurations;

namespace LogViewer.Unicorn
{
    public partial class SqlForm : Form
    {
        public SqlForm()
        {
            InitializeComponent();
        }

        private void AcceptCOnfigurationButton_Click(object sender, EventArgs e)
        {
            SqlConfigurations.Warns = checkBoxAcceptWarns.Checked;
            SqlConfigurations.Errors = checkBoxIncludeErrors.Checked;
            SqlConfigurations.Sentence1 = IncludeText.Text;
            SqlConfigurations.Sentence2 = Include_2Text.Text;
            this.Close();
        }
    }
}
