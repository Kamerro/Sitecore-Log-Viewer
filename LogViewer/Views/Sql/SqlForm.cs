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
                SqlConfigurations.Warns = true;

            if (checkBoxIncludeErrors.Checked)
                SqlConfigurations.Errors = true;

            if (checkBoxIncludeSentence1.Checked)
                SqlConfigurations.Sentence1 = IncludeText.Text;

            if (checkBoxIncludeSentence2.Checked)
                SqlConfigurations.Sentence2 = Include_2Text.Text;

            this.Close();
        }
    }
}
