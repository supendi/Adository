namespace Adository.VB.UI.ServerBrowser
{
    public abstract class ServerBrowserCommandBase
    {
        protected abstract void InitEvents();
        protected ServerBrowserForm Form { get; private set; }
        public ServerBrowserCommandBase(ServerBrowserForm form)
        {
            this.Form = form;
            InitEvents();
        }
    }
}
