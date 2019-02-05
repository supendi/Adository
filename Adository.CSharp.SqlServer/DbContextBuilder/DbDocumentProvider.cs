using Adository.CSharp.SqlServer.Models;
using System.Data;
namespace Adository.CSharp.SqlServer.DbContextBuilder
{
    /// <summary>
    /// DbContext document provider.
    /// </summary>
    public class DbDocumentProvider : DocumentProviderBase<DbClass>
    {
        public DbDocumentProvider()
        {
        }

        protected string[] GetUsingList(string defaultNamespaceName)
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                $"{defaultNamespaceName}.RepositoryPacks",
            };
        }

        public CSDocument Create(DataSet dataset, string dbContextName, string defaultNamespaceName, string projectName)
        {
            DbClass cls = new DbClass(dataset, dbContextName);
            CSDocument document = new CSDocument(dbContextName, projectName);
            CSNamespace ns = CreateNamespace(defaultNamespaceName, GetUsingList(defaultNamespaceName), cls);
            document.Namespaces.Add(ns);

            return document;
        }
    }
}
