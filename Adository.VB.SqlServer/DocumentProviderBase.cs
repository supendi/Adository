using Adository.VB.SqlServer.Models;

namespace Adository.VB.SqlServer
{
    public abstract class DocumentProviderBase<T> where T : VBClass
    {
        protected virtual VBNamespace CreateNamespace(string namespaceName, string[] usingNamespaceList, T cls)
        {
            VBNamespace ns = new VBNamespace(namespaceName, false);
            foreach (var item in usingNamespaceList)
            {
                ns.IncludeNamespaces.Add($"Imports {item}");
            }
            ns.Classes.Add(cls);

            return ns;
        }
    }
}
