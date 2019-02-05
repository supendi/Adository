namespace Adository.CSharp.UI.Generator
{
    partial class GeneratorForm
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
            this.txtSaveToFolder = new Pend.WFL.Controls.PendTextBox();
            this.txtProjectName = new Pend.WFL.Controls.PendTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDbContext = new Pend.WFL.Controls.PendTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSelectedDatabase = new Pend.WFL.Controls.PendTextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNamespaceName = new Pend.WFL.Controls.PendTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSaveToFolder
            // 
            this.txtSaveToFolder.BrowseButton = null;
            this.txtSaveToFolder.ErrorMessage = null;
            this.txtSaveToFolder.FieldName = null;
            this.txtSaveToFolder.Location = new System.Drawing.Point(126, 123);
            this.txtSaveToFolder.Name = "txtSaveToFolder";
            this.txtSaveToFolder.PendValue = "";
            this.txtSaveToFolder.ShowButton = false;
            this.txtSaveToFolder.Size = new System.Drawing.Size(251, 20);
            this.txtSaveToFolder.TabIndex = 9;
            // 
            // txtProjectName
            // 
            this.txtProjectName.BrowseButton = null;
            this.txtProjectName.ErrorMessage = null;
            this.txtProjectName.FieldName = null;
            this.txtProjectName.Location = new System.Drawing.Point(126, 45);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.PendValue = "";
            this.txtProjectName.ShowButton = false;
            this.txtProjectName.Size = new System.Drawing.Size(251, 20);
            this.txtProjectName.TabIndex = 6;
            this.txtProjectName.TextChanged += new System.EventHandler(this.txtProjectName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Save to folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Project name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDbContext);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSelectedDatabase);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNamespaceName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSaveToFolder);
            this.groupBox1.Controls.Add(this.txtProjectName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 163);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup Folder";
            // 
            // txtDbContext
            // 
            this.txtDbContext.BrowseButton = null;
            this.txtDbContext.ErrorMessage = null;
            this.txtDbContext.FieldName = null;
            this.txtDbContext.Location = new System.Drawing.Point(126, 97);
            this.txtDbContext.Name = "txtDbContext";
            this.txtDbContext.PendValue = "";
            this.txtDbContext.ShowButton = false;
            this.txtDbContext.Size = new System.Drawing.Size(251, 20);
            this.txtDbContext.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "DbContext Name:";
            // 
            // txtSelectedDatabase
            // 
            this.txtSelectedDatabase.BrowseButton = null;
            this.txtSelectedDatabase.ErrorMessage = null;
            this.txtSelectedDatabase.FieldName = null;
            this.txtSelectedDatabase.Location = new System.Drawing.Point(126, 19);
            this.txtSelectedDatabase.Name = "txtSelectedDatabase";
            this.txtSelectedDatabase.PendValue = "";
            this.txtSelectedDatabase.ReadOnly = true;
            this.txtSelectedDatabase.ShowButton = false;
            this.txtSelectedDatabase.Size = new System.Drawing.Size(251, 20);
            this.txtSelectedDatabase.TabIndex = 5;
            this.txtSelectedDatabase.TabStop = false;
            this.txtSelectedDatabase.TextChanged += new System.EventHandler(this.txtSelectedDatabase_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(383, 121);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 10;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Selected Database:";
            // 
            // txtNamespaceName
            // 
            this.txtNamespaceName.BrowseButton = null;
            this.txtNamespaceName.ErrorMessage = null;
            this.txtNamespaceName.FieldName = null;
            this.txtNamespaceName.Location = new System.Drawing.Point(126, 71);
            this.txtNamespaceName.Name = "txtNamespaceName";
            this.txtNamespaceName.PendValue = "";
            this.txtNamespaceName.ShowButton = false;
            this.txtNamespaceName.Size = new System.Drawing.Size(251, 20);
            this.txtNamespaceName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Namespace name:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(400, 181);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(332, 181);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // GeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.KeyPreview = true;
            this.Name = "GeneratorForm";
            this.Text = "GeneratorForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GeneratorForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Pend.WFL.Controls.PendTextBox txtSaveToFolder;
        private Pend.WFL.Controls.PendTextBox txtProjectName;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Pend.WFL.Controls.PendTextBox txtDbContext;
        public System.Windows.Forms.Label label5;
        private Pend.WFL.Controls.PendTextBox txtSelectedDatabase;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.Label label4;
        private Pend.WFL.Controls.PendTextBox txtNamespaceName;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}