using LogViewer.Configurations;
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
            SolrConfigurations.Warns = checkBoxAcceptWarns.Checked;
            SolrConfigurations.Errors = checkBoxIncludeErrors.Checked;
            SolrConfigurations.Sentence1 = IncludeText.Text;
            SolrConfigurations.Sentence2 = Include_2Text.Text;

            this.Close();
        }
    }
}
