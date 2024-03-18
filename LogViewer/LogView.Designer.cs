namespace LogViewer
{
    partial class LogView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SqlLogButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OtherLogButton = new System.Windows.Forms.Button();
            this.logViewBox = new System.Windows.Forms.RichTextBox();
            this.SolrLogButton = new System.Windows.Forms.Button();
            this.UnicornLogButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SqlLogButton
            // 
            this.SqlLogButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SqlLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SqlLogButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SqlLogButton.Location = new System.Drawing.Point(14, 10);
            this.SqlLogButton.Name = "SqlLogButton";
            this.SqlLogButton.Size = new System.Drawing.Size(237, 89);
            this.SqlLogButton.TabIndex = 0;
            this.SqlLogButton.Text = "Show sql logs";
            this.SqlLogButton.UseVisualStyleBackColor = false;
            this.SqlLogButton.Click += new System.EventHandler(this.SqlLogButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OtherLogButton);
            this.panel1.Controls.Add(this.logViewBox);
            this.panel1.Controls.Add(this.SolrLogButton);
            this.panel1.Controls.Add(this.UnicornLogButton);
            this.panel1.Controls.Add(this.SqlLogButton);
            this.panel1.Location = new System.Drawing.Point(-6, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 784);
            this.panel1.TabIndex = 3;
            // 
            // OtherLogButton
            // 
            this.OtherLogButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OtherLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OtherLogButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OtherLogButton.Location = new System.Drawing.Point(14, 105);
            this.OtherLogButton.Name = "OtherLogButton";
            this.OtherLogButton.Size = new System.Drawing.Size(723, 89);
            this.OtherLogButton.TabIndex = 4;
            this.OtherLogButton.Text = "Show other logs";
            this.OtherLogButton.UseVisualStyleBackColor = false;
            this.OtherLogButton.Click += new System.EventHandler(this.OtherLogButton_Click);
            // 
            // logViewBox
            // 
            this.logViewBox.Location = new System.Drawing.Point(14, 209);
            this.logViewBox.Name = "logViewBox";
            this.logViewBox.Size = new System.Drawing.Size(723, 545);
            this.logViewBox.TabIndex = 3;
            this.logViewBox.Text = "";
            // 
            // SolrLogButton
            // 
            this.SolrLogButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SolrLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SolrLogButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SolrLogButton.Location = new System.Drawing.Point(500, 10);
            this.SolrLogButton.Name = "SolrLogButton";
            this.SolrLogButton.Size = new System.Drawing.Size(237, 89);
            this.SolrLogButton.TabIndex = 2;
            this.SolrLogButton.Text = "Show solr config";
            this.SolrLogButton.UseVisualStyleBackColor = false;
            this.SolrLogButton.Click += new System.EventHandler(this.SolrLogButton_Click);
            // 
            // UnicornLogButton
            // 
            this.UnicornLogButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.UnicornLogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UnicornLogButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.UnicornLogButton.Location = new System.Drawing.Point(257, 10);
            this.UnicornLogButton.Name = "UnicornLogButton";
            this.UnicornLogButton.Size = new System.Drawing.Size(237, 89);
            this.UnicornLogButton.TabIndex = 1;
            this.UnicornLogButton.Text = "Show unicorn logs";
            this.UnicornLogButton.UseVisualStyleBackColor = false;
            this.UnicornLogButton.Click += new System.EventHandler(this.UnicornLogButton_Click);
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 762);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LogView";
            this.Text = "LogView";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SqlLogButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox logViewBox;
        private System.Windows.Forms.Button SolrLogButton;
        private System.Windows.Forms.Button UnicornLogButton;
        private System.Windows.Forms.Button OtherLogButton;
    }
}