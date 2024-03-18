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
            if (checkBoxAcceptWarns.Checked)
                UnicornConfigurations.Warns = true;

            if (checkBoxIncludeErrors.Checked)
                UnicornConfigurations.Errors = true;

            if (checkBoxIncludeSentence1.Checked)
                UnicornConfigurations.Sentence1 = IncludeText.Text;

            if (checkBoxIncludeSentence2.Checked)
                UnicornConfigurations.Sentence2 = Include_2Text.Text;

            this.Close();
        }
    }
}
