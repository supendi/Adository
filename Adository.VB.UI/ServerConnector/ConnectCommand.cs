using Adository.Common;
using Adository.Data.SqlServer;
using Adository.WFL;
using System.Linq;
using System.Windows.Forms;

namespace Adository.VB.UI.ServerConnector
{
    public enum AuthType
    {
        Windows,
        SqlServer
    }

    public class ConnectCommand : ServerConnectorCommandBase
    {
        public ConnectCommand(ServerConnectorForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            Form.OK.Click += OnClick;
        }

        private DbServerModel GetServerModel()
        {
            try
            {
                Form.Cursor = Cursors.WaitCursor;
                var builder = new ConnectionStringBuilder(Form.ServerName, "master", Form.UserName, Form.Password, Form.AuthType == AuthType.Windows);
                SqlConnectionSingleton.SetConnectionString(builder.MasterConnectionString);
                Form.Cursor = Cursors.Default;
                return DbServerManagerSingleton.GetInstance().Connect();
            }
            catch (System.Exception ex)
            {
                Form.Cursor = Cursors.Default;
                MsgBox.ShowError(ex.Message);
                return null;
            }
        }

        private bool IsValidInput()
        {
            if (Form.AuthType == AuthType.SqlServer && (string.IsNullOrEmpty(Form.UserName) || string.IsNullOrEmpty(Form.Password)))
            {
                MsgBox.ShowError("Username and password is required");
                return false;
            }
            return true;
        }

        private void AddNewServerToServerBrowser()
        {
            if (IsValidInput())
            {
                var server = GetServerModel();
                if (server != null)
                {
                    ServerBrowser.AddNewServerCommand addNewServerCommand = new ServerBrowser.AddNewServerCommand(Form.ServerBrowserForm);
                    addNewServerCommand.AddNewServer(server);
                    Form.Close();
                }
            }
        }

        private void OnClick(object sender, System.EventArgs e)
        {
            var alreadyExist = Form.ServerBrowserForm.DbServers.Where(x => x == Form.ServerName).Count() > 0;
            if (alreadyExist)
            {
                MsgBox.ShowError("Server name already exist.");
                return;
            }

            AddNewServerToServerBrowser();
        }
    }
}
