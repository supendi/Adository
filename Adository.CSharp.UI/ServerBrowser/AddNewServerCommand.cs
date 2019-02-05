using Adository.Common;
using Adository.CSharp.UI.Nodes;

namespace Adository.CSharp.UI.ServerBrowser
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
