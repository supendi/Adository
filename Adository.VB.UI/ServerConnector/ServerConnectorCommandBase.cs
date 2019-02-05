namespace Adository.VB.UI.ServerConnector
{

    public abstract class ServerConnectorCommandBase
    {
        protected abstract void InitEvents();
        protected ServerConnectorForm Form { get; private set; }
        public ServerConnectorCommandBase(ServerConnectorForm form)
        {
            this.Form = form;
            InitEvents();
        }
    }
}
