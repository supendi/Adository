namespace Adository
{
    partial class LauncherForm
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
            this.csRadio = new System.Windows.Forms.RadioButton();
            this.vbRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // csRadio
            // 
            this.csRadio.AutoSize = true;
            this.csRadio.Checked = true;
            this.csRadio.Location = new System.Drawing.Point(38, 31);
            this.csRadio.Name = "csRadio";
            this.csRadio.Size = new System.Drawing.Size(39, 17);
            this.csRadio.TabIndex = 0;
            this.csRadio.TabStop = true;
            this.csRadio.Text = "C#";
            this.csRadio.UseVisualStyleBackColor = true;
            // 
            // vbRadio
            // 
            this.vbRadio.AutoSize = true;
            this.vbRadio.Location = new System.Drawing.Point(125, 31);
            this.vbRadio.Name = "vbRadio";
            this.vbRadio.Size = new System.Drawing.Size(82, 17);
            this.vbRadio.TabIndex = 1;
            this.vbRadio.Text = "Visual Basic";
            this.vbRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.csRadio);
            this.groupBox1.Controls.Add(this.vbRadio);
            this.groupBox1.Location = new System.Drawing.Point(120, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pick Language";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(120, 154);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(245, 35);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adository";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton csRadio;
        private System.Windows.Forms.RadioButton vbRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
    }
}

