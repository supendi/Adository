using Adository.VB.UI.ServerBrowser;
using Adository.VB.UI.ServerConnector;
using System;
using System.Windows.Forms;

namespace Adository.VB.UI.Main
{
    public partial class MainForm : Form
    {
        public ServerBrowserForm ServerBrowser { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void ShowServerBrowser()
        {
            ServerBrowserForm frmServerBrowser = new ServerBrowserForm();
            ConfigureServerBrowser(frmServerBrowser);

            splitContainer.Panel1.Controls.Add(frmServerBrowser);
            frmServerBrowser.Show();
        }

        private void ConfigureServerBrowser(ServerBrowserForm frmServerBrowser)
        {
            this.ServerBrowser = frmServerBrowser;
            this.ServerBrowser.MainForm = this;

            frmServerBrowser.TopLevel = false;
            frmServerBrowser.FormBorderStyle = FormBorderStyle.None;
            frmServerBrowser.WindowState = FormWindowState.Minimized;
            frmServerBrowser.WindowState = FormWindowState.Maximized;
            frmServerBrowser.Dock = DockStyle.Fill;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowServerBrowser();
            ServerConnectorForm frm = new ServerConnectorForm(ServerBrowser);
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
