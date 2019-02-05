using Adository.VB.UI.ServerBrowser;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerConnector
{
    public partial class ServerConnectorForm : Form
    {
        ConnectCommand connectCommand;

        public ServerBrowserForm ServerBrowserForm { get; set; }

        public string ServerName
        {
            get
            {
                return cboServerName.Text;
            }
            set
            {
                cboServerName.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return txtUserName.Text;
            }
            set
            {
                txtUserName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }

        public AuthType AuthType
        {
            get
            {
                return (cboAuthType.Text == "Windows") ? AuthType.Windows : AuthType.SqlServer;
            }
        }

        public Button OK
        {
            get
            {
                return btnOK;
            }
        }

        public void InitCommands()
        {
            connectCommand = new ConnectCommand(this);
        }

        public ServerConnectorForm()
        {
            InitializeComponent();

            InitCommands();
        }

        public ServerConnectorForm(ServerBrowserForm frmServerBrowser)
        {
            InitializeComponent();

            InitCommands();
            ServerBrowserForm = frmServerBrowser;
        }

        private void FrmLogin_Load(object sender, System.EventArgs e)
        {
            cboAuthType.SelectedIndex = 1;
        }

        private void cboAuthType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cboAuthType.SelectedIndex == 1)
            {
                txtUserName.Clear();
                txtPassword.Clear();

                txtUserName.Enabled = false;
                txtPassword.Enabled = false;

                return;
            }

            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
        }
    }
}
