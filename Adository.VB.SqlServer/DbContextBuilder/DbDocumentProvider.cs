using Adository.VB.SqlServer.Models;
using System.Data;
namespace Adository.VB.SqlServer.DbContextBuilder
{
    /// <summary>
    /// DbContext document provider.
    /// </summary>
    public class DbDocumentProvider : DocumentProviderBase<DbClass>
    {
        public DbDocumentProvider()
        {
        }

        protected string[] GetUsingList(string defaultNamespaceName, string projectName)
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                $"{projectName}.{defaultNamespaceName}.RepositoryPacks",
            };
        }

        public VBDocument Create(DataSet dataset, string dbContextName, string defaultNamespaceName, string projectName)
        {
            DbClass cls = new DbClass(dataset, dbContextName);
            VBDocument document = new VBDocument(dbContextName, projectName);
            VBNamespace ns = CreateNamespace(defaultNamespaceName, GetUsingList(defaultNamespaceName, projectName), cls);
            document.Namespaces.Add(ns);

            return document;
        }
    }
}
