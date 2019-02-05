using Adository.VB.UI.Nodes;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.Generator
{
    public partial class GeneratorForm : Form
    {
        BrowseFolderCommand browseFolderCommand;
        SaveAllCommand saveAllCommand;

        public string ProjectFolder
        {
            get
            {
                return txtSaveToFolder.Text;
            }
            set
            {
                txtSaveToFolder.Text = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return txtProjectName.Text;
            }
            set
            {
                txtProjectName.Text = value;
            }
        }

        public string NamespaceName
        {
            get
            {
                return txtNamespaceName.Text;
            }
            set
            {
                txtNamespaceName.Text = value;
            }
        }

        public string SelectedDatabaseName
        {
            get
            {
                return txtSelectedDatabase.Text;
            }
            set
            {
                txtSelectedDatabase.Text = value;
                txtDbContext.Text = $"{value}Db";
            }
        }

        public string DbContextName
        {
            get
            {
                return txtDbContext.Text;
            }
            set
            {
                txtDbContext.Text = value;
            }
        }

        public DatabaseNode SelectedDbNode { get; private set; }

     

        public Button Browse
        {
            get
            {
                return btnBrowse;
            }
        }

        public Button OK
        {
            get
            {
                return btnOK;
            }
        }

        public GeneratorForm(DatabaseNode selectedDbNode)
        {
            InitializeComponent();
            SelectedDbNode = selectedDbNode;
            SelectedDatabaseName = selectedDbNode.Name;
            NamespaceName = SelectedDbNode.Name + ".Db";

            InitCommands();
        }

        public void InitCommands()
        {
            browseFolderCommand = new BrowseFolderCommand(this);
            saveAllCommand = new SaveAllCommand(this);
        }
         
        private void txtSelectedDatabase_TextChanged(object sender, EventArgs e)
        {
            txtProjectName.Text = txtSelectedDatabase.Text + ".Db";
            txtNamespaceName.Text = txtSelectedDatabase.Text;
        }

        private void txtProjectName_TextChanged(object sender, EventArgs e)
        {
            txtNamespaceName.Text = txtProjectName.Text;
            txtDbContext.Text = txtProjectName.Text.Replace(".", "");
        }

        private void GeneratorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
