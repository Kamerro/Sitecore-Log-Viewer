using LogViewer.Solr;
using LogViewer.Unicorn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogViewer.Unicorn;
using LogViewer.Sql;
namespace LogViewer
{
    public partial class LogView : Form
    {
        private WindowSettings _settings;
        public LogView(WindowSettings settings)
        {
            InitializeComponent();
            _settings = settings;
            ReadSettings();
        }

        private void ReadSettings()
        {
            foreach (var obj in _settings.Properties)
            {
                if(obj.Name == "Background-color")
                {
                    panel1.BackColor = Color.FromName(obj.Value);
                }

            }
        }

        private void SqlLogButton_Click(object sender, EventArgs e)
        {
            logViewBox.Clear();
            SqlForm sqlConfig = new SqlForm();
            sqlConfig.ShowDialog();

            if (SqlConfigurations.Warns)
                Placeholder.ListWarningsSql.Where(
                    x => x.Contains(SqlConfigurations.Sentence1)
                    && x.Contains(SqlConfigurations.Sentence2))
                    .ToList()
                    .ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));

            if (SqlConfigurations.Errors)
                Placeholder.ListErrorsSql.Where(
                  x => x.Contains(SqlConfigurations.Sentence1)
               && x.Contains(SqlConfigurations.Sentence2))
                  .ToList()
                  .ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));
        }

        private void OtherLogButton_Click(object sender, EventArgs e)
        {
            Placeholder.ListOfOtherWarns.ForEach(x => { logViewBox.AppendText(x.ToString() + "\r\n"); });
        }

        private void SolrLogButton_Click(object sender, EventArgs e)
        {
            logViewBox.Clear();
            solrConfig solrConfig = new solrConfig();
            solrConfig.ShowDialog();
            List<string> kurwenmahen = new List<string>();

            if (SolrConfigurations.Warns)
                Placeholder.ListWarningsSolr.Where(
                    x=>x.Contains(SolrConfigurations.Sentence1)
                    && x.Contains(SolrConfigurations.Sentence2))
                    .ToList()
                    .ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));

            if (SolrConfigurations.Errors)
                Placeholder.ListErrorsSolr.Where(
                  x => x.Contains(SolrConfigurations.Sentence1)
               && x.Contains(SolrConfigurations.Sentence2))
                  .ToList()
                  .ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));


        }

        private void UnicornLogButton_Click(object sender, EventArgs e)
        {
            logViewBox.Clear();
            UnicornForm unicornForm = new UnicornForm();
            unicornForm.ShowDialog();

            if (UnicornConfigurations.Warns)
                Placeholder.ListWarningsUnicorn.Where(
                    x => x.Contains(UnicornConfigurations.Sentence1)
                 && x.Contains(UnicornConfigurations.Sentence2))
                    .ToList().ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));

            if (UnicornConfigurations.Errors)
                Placeholder.ListErrorsUnicorn.Where(
                  x => x.Contains(UnicornConfigurations.Sentence1)
               && x.Contains(UnicornConfigurations.Sentence2))
                  .ToList().ForEach(x => logViewBox.AppendText(x.ToString() + "\r\n"));


        }
    }
}
