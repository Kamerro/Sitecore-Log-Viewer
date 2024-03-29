﻿namespace LogViewer
{
    partial class BaseForm
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
            this.LoadLog.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.LoadLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoadLog.Location = new System.Drawing.Point(13, 13);
            this.LoadLog.Name = "LoadLog";
            this.LoadLog.Size = new System.Drawing.Size(399, 121);
            this.LoadLog.TabIndex = 0;
            this.LoadLog.Text = "Choose the log file";
            this.LoadLog.UseVisualStyleBackColor = false;
            this.LoadLog.Click += new System.EventHandler(this.LoadLog_Click);
            // 
            // LogViewerBox
            // 
            this.LogViewerBox.Location = new System.Drawing.Point(75, 140);
            this.LogViewerBox.Name = "LogViewerBox";
            this.LogViewerBox.Size = new System.Drawing.Size(244, 283);
            this.LogViewerBox.TabIndex = 1;
            this.LogViewerBox.Text = "";
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(426, 450);
            this.Controls.Add(this.LogViewerBox);
            this.Controls.Add(this.LoadLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BaseForm";
            this.Text = "Log simplifier";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadLog;
        private System.Windows.Forms.RichTextBox LogViewerBox;
    }
}

