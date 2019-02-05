using Adository.Common;
using Adository.VB.UI.Nodes;

namespace Adository.VB.UI.ServerBrowser
{
    public class AddNewServerCommand : ServerBrowserCommandBase
    {
        public AddNewServerCommand(ServerBrowserForm form) : base(form)
        {
        }

        protected override void InitEvents()
        {
            //throw new NotImplementedException();
        }

        public void AddNewServer(DbServerModel server)
        {
            var serverNode = new ServerNode(server);
            Form.TreeView.Nodes.Add(serverNode);
        }
    }
}
