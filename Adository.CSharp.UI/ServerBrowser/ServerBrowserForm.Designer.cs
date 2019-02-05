namespace Adository.CSharp.UI.ServerBrowser
{
    partial class ServerBrowserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerBrowserForm));
            this.refreshTableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPreviewDeleteClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviewUpdateClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviewInsertClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviewSelectClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPreviewModelClass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviewRepositoryPackClass = new System.Windows.Forms.ToolStripMenuItem();
            this.tableContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disconnectServerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshServerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.serverContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshDatabaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.generateRepositoryMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dbContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.openServerConnectorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableContextMenu.SuspendLayout();
            this.serverContextMenu.SuspendLayout();
            this.dbContextMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshTableMenu
            // 
            this.refreshTableMenu.Name = "refreshTableMenu";
            this.refreshTableMenu.Size = new System.Drawing.Size(180, 22);
            this.refreshTableMenu.Text = "Refresh";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuPreviewDeleteClass
            // 
            this.mnuPreviewDeleteClass.Name = "mnuPreviewDeleteClass";
            this.mnuPreviewDeleteClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewDeleteClass.Text = "Delete Class";
            // 
            // mnuPreviewUpdateClass
            // 
            this.mnuPreviewUpdateClass.Name = "mnuPreviewUpdateClass";
            this.mnuPreviewUpdateClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewUpdateClass.Text = "Update Class";
            // 
            // mnuPreviewInsertClass
            // 
            this.mnuPreviewInsertClass.Name = "mnuPreviewInsertClass";
            this.mnuPreviewInsertClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewInsertClass.Text = "Insert Class";
            // 
            // mnuPreviewSelectClass
            // 
            this.mnuPreviewSelectClass.Name = "mnuPreviewSelectClass";
            this.mnuPreviewSelectClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewSelectClass.Text = "Query Class";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuPreviewModelClass
            // 
            this.mnuPreviewModelClass.Name = "mnuPreviewModelClass";
            this.mnuPreviewModelClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewModelClass.Text = "Model Class";
            // 
            // mnuPreview
            // 
            this.mnuPreview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPreviewModelClass,
            this.toolStripMenuItem1,
            this.mnuPreviewSelectClass,
            this.mnuPreviewInsertClass,
            this.mnuPreviewUpdateClass,
            this.mnuPreviewDeleteClass,
            this.toolStripMenuItem2,
            this.mnuPreviewRepositoryPackClass});
            this.mnuPreview.Name = "mnuPreview";
            this.mnuPreview.Size = new System.Drawing.Size(180, 22);
            this.mnuPreview.Text = "Preview";
            // 
            // mnuPreviewRepositoryPackClass
            // 
            this.mnuPreviewRepositoryPackClass.Name = "mnuPreviewRepositoryPackClass";
            this.mnuPreviewRepositoryPackClass.Size = new System.Drawing.Size(188, 22);
            this.mnuPreviewRepositoryPackClass.Text = "Repository Pack Class";
            // 
            // tableContextMenu
            // 
            this.tableContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPreview,
            this.refreshTableMenu});
            this.tableContextMenu.Name = "contextMenuStrip";
            this.tableContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // disconnectServerMenu
            // 
            this.disconnectServerMenu.Name = "disconnectServerMenu";
            this.disconnectServerMenu.Size = new System.Drawing.Size(133, 22);
            this.disconnectServerMenu.Text = "Disconnect";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(130, 6);
            // 
            // refreshServerMenu
            // 
            this.refreshServerMenu.Name = "refreshServerMenu";
            this.refreshServerMenu.Size = new System.Drawing.Size(133, 22);
            this.refreshServerMenu.Text = "Refresh";
            // 
            // serverContextMenu
            // 
            this.serverContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshServerMenu,
            this.toolStripMenuItem3,
            this.disconnectServerMenu});
            this.serverContextMenu.Name = "contextMenuStrip";
            this.serverContextMenu.Size = new System.Drawing.Size(134, 54);
            // 
            // refreshDatabaseMenu
            // 
            this.refreshDatabaseMenu.Name = "refreshDatabaseMenu";
            this.refreshDatabaseMenu.Size = new System.Drawing.Size(180, 22);
            this.refreshDatabaseMenu.Text = "Refresh";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 6);
            // 
            // generateRepositoryMenu
            // 
            this.generateRepositoryMenu.Name = "generateRepositoryMenu";
            this.generateRepositoryMenu.Size = new System.Drawing.Size(180, 22);
            this.generateRepositoryMenu.Text = "Generate Repository";
            // 
            // dbContextMenu
            // 
            this.dbContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateRepositoryMenu,
            this.openToolStripMenuItem,
            this.refreshDatabaseMenu});
            this.dbContextMenu.Name = "contextMenuStrip";
            this.dbContextMenu.Size = new System.Drawing.Size(181, 54);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "icons8-workstation-16 (2).png");
            this.imageList.Images.SetKeyName(1, "icons8-database-32.png");
            this.imageList.Images.SetKeyName(2, "icons8-data-sheet-filled-16 (1).png");
            this.imageList.Images.SetKeyName(3, "icons8-select-column-16.png");
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.imageList;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(284, 415);
            this.treeView.TabIndex = 0;
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // openServerConnectorButton
            // 
            this.openServerConnectorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openServerConnectorButton.Image = ((System.Drawing.Image)(resources.GetObject("openServerConnectorButton.Image")));
            this.openServerConnectorButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openServerConnectorButton.Name = "openServerConnectorButton";
            this.openServerConnectorButton.Size = new System.Drawing.Size(23, 22);
            this.openServerConnectorButton.Text = "New";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openServerConnectorButton});
            this.toolStrip.Location = new System.Drawing.Point(5, 5);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(274, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "ToolStrip";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView);
            this.splitContainer1.Size = new System.Drawing.Size(284, 450);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 3;
            this.splitContainer1.TabStop = false;
            // 
            // ServerBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ServerBrowserForm";
            this.Text = "Server Browser";
            this.tableContextMenu.ResumeLayout(false);
            this.serverContextMenu.ResumeLayout(false);
            this.dbContextMenu.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuPreview;
        private System.Windows.Forms.ContextMenuStrip tableContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator openToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip dbContextMenu;
        private System.Windows.Forms.ImageList imageList;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.ContextMenuStrip serverContextMenu;
        public System.Windows.Forms.ToolStripMenuItem disconnectServerMenu;
        public System.Windows.Forms.ToolStripMenuItem refreshDatabaseMenu;
        public System.Windows.Forms.ToolStripMenuItem generateRepositoryMenu;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewDeleteClass;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewUpdateClass;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewInsertClass;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewSelectClass;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewModelClass;
        public System.Windows.Forms.ToolStripMenuItem mnuPreviewRepositoryPackClass;
        public System.Windows.Forms.ToolStripMenuItem refreshTableMenu;
        public System.Windows.Forms.ToolStripMenuItem refreshServerMenu;
        public System.Windows.Forms.ToolStripButton openServerConnectorButton;
    }
}