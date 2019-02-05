using Adository.CSharp.SqlServer.Models;

namespace Adository.CSharp.SqlServer
{
    public abstract class DocumentProviderBase<T> where T : CSClass
    {
        protected virtual CSNamespace CreateNamespace(string namespaceName, string[] usingNamespaceList, T cls)
        {
            CSNamespace ns = new CSNamespace(namespaceName, false);
            foreach (var item in usingNamespaceList)
            {
                ns.IncludeNamespaces.Add($"using {item};");
            }
            ns.Classes.Add(cls);

            return ns;
        }
    }
}
