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

namespace LogViewer
{
    public partial class solrConfig : Form
    {
        public solrConfig()
        {
            InitializeComponent();
        }

        private void AcceptCOnfigurationButton_Click(object sender, EventArgs e)
        {
            if (checkBoxAcceptWarns.Checked)
                SolrConfigurations.Warns = true;

            if(checkBoxIncludeErrors.Checked)
                SolrConfigurations.Errors = true;

            if (checkBoxIncludeSentence1.Checked)
                SolrConfigurations.Sentence1 = IncludeText.Text;

            if (checkBoxIncludeSentence2.Checked)
                SolrConfigurations.Sentence2 = Include_2Text.Text;

            this.Close();
        }
    }
}
