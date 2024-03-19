namespace LogViewer.Unicorn
{
    partial class UnicornForm
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
            this.Include_2Text = new System.Windows.Forms.TextBox();
            this.IncludeText = new System.Windows.Forms.TextBox();
            this.checkBoxIncludeErrors = new System.Windows.Forms.CheckBox();
            this.checkBoxAcceptWarns = new System.Windows.Forms.CheckBox();
            this.AcceptCOnfigurationButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Include_2Text
            // 
            this.Include_2Text.Location = new System.Drawing.Point(150, 119);
            this.Include_2Text.Name = "Include_2Text";
            this.Include_2Text.Size = new System.Drawing.Size(165, 22);
            this.Include_2Text.TabIndex = 13;
            // 
            // IncludeText
            // 
            this.IncludeText.Location = new System.Drawing.Point(150, 91);
            this.IncludeText.Name = "IncludeText";
            this.IncludeText.Size = new System.Drawing.Size(165, 22);
            this.IncludeText.TabIndex = 12;
            // 
            // checkBoxIncludeErrors
            // 
            this.checkBoxIncludeErrors.AutoSize = true;
            this.checkBoxIncludeErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxIncludeErrors.Location = new System.Drawing.Point(9, 35);
            this.checkBoxIncludeErrors.Name = "checkBoxIncludeErrors";
            this.checkBoxIncludeErrors.Size = new System.Drawing.Size(78, 24);
            this.checkBoxIncludeErrors.TabIndex = 9;
            this.checkBoxIncludeErrors.Text = "Errors";
            this.checkBoxIncludeErrors.UseVisualStyleBackColor = true;
            // 
            // checkBoxAcceptWarns
            // 
            this.checkBoxAcceptWarns.AutoSize = true;
            this.checkBoxAcceptWarns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.checkBoxAcceptWarns.Location = new System.Drawing.Point(9, 9);
            this.checkBoxAcceptWarns.Name = "checkBoxAcceptWarns";
            this.checkBoxAcceptWarns.Size = new System.Drawing.Size(80, 24);
            this.checkBoxAcceptWarns.TabIndex = 8;
            this.checkBoxAcceptWarns.Text = "Warns";
            this.checkBoxAcceptWarns.UseVisualStyleBackColor = true;
            // 
            // AcceptCOnfigurationButton
            // 
            this.AcceptCOnfigurationButton.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.AcceptCOnfigurationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptCOnfigurationButton.Location = new System.Drawing.Point(21, 154);
            this.AcceptCOnfigurationButton.Name = "AcceptCOnfigurationButton";
            this.AcceptCOnfigurationButton.Size = new System.Drawing.Size(247, 163);
            this.AcceptCOnfigurationButton.TabIndex = 7;
            this.AcceptCOnfigurationButton.Text = "Accept configuration";
            this.AcceptCOnfigurationButton.UseVisualStyleBackColor = false;
            this.AcceptCOnfigurationButton.Click += new System.EventHandler(this.AcceptCOnfigurationButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(77, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Include:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(77, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Include:";
            // 
            // UnicornForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(335, 325);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Include_2Text);
            this.Controls.Add(this.IncludeText);
            this.Controls.Add(this.checkBoxIncludeErrors);
            this.Controls.Add(this.checkBoxAcceptWarns);
            this.Controls.Add(this.AcceptCOnfigurationButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UnicornForm";
            this.Text = "UnicornForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Include_2Text;
        private System.Windows.Forms.TextBox IncludeText;
        private System.Windows.Forms.CheckBox checkBoxIncludeErrors;
        private System.Windows.Forms.CheckBox checkBoxAcceptWarns;
        private System.Windows.Forms.Button AcceptCOnfigurationButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}