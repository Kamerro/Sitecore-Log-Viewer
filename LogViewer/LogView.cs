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
    }
}
