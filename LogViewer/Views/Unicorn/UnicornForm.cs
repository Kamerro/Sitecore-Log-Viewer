using LogViewer.Solr;
using LogViewer.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogViewer.Unicorn
{
    public partial class UnicornForm : Form
    {
        public UnicornForm()
        {
            InitializeComponent();
        }

        private void AcceptCOnfigurationButton_Click(object sender, EventArgs e)
        {
            UnicornConfigurations.Warns = checkBoxAcceptWarns.Checked;
            UnicornConfigurations.Errors = checkBoxIncludeErrors.Checked;
            UnicornConfigurations.Sentence1 = IncludeText.Text;
            UnicornConfigurations.Sentence2 = Include_2Text.Text;
            this.Close();
        }
    }
}
