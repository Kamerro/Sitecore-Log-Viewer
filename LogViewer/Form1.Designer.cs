namespace LogViewer
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadLog = new System.Windows.Forms.Button();
            this.LogViewerBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // LoadLog
            // 
            this.LoadLog.Location = new System.Drawing.Point(13, 13);
            this.LoadLog.Name = "LoadLog";
            this.LoadLog.Size = new System.Drawing.Size(775, 121);
            this.LoadLog.TabIndex = 0;
            this.LoadLog.Text = "Choose the file";
            this.LoadLog.UseVisualStyleBackColor = true;
            this.LoadLog.Click += new System.EventHandler(this.LoadLog_Click);
            // 
            // LogViewerBox
            // 
            this.LogViewerBox.Location = new System.Drawing.Point(13, 141);
            this.LogViewerBox.Name = "LogViewerBox";
            this.LogViewerBox.Size = new System.Drawing.Size(775, 283);
            this.LogViewerBox.TabIndex = 1;
            this.LogViewerBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LogViewerBox);
            this.Controls.Add(this.LoadLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadLog;
        private System.Windows.Forms.RichTextBox LogViewerBox;
    }
}

