using Adository.VB.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.VB.SqlServer.RepositoryPackBuilder
{
    public class RepositoryPackDocumentProvider : DocumentProviderBase<RepositoryPackClass>
    {
        string suffix = "Repository";

        public RepositoryPackDocumentProvider()
        {
        }

        protected string[] GetUsingList(string namespaceName, string tableName, string projectName)
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                $"{projectName}.{namespaceName}.{tableName}Repository"
            };
        }

        private string CreateNamespaceName(string namespaceName, string tableName)
        {
            return $"{namespaceName}.RepositoryPacks";
        }

        private VBDocument Create(DataTable dataTable, string namespaceName, string projectName)
        { 
            RepositoryPackClass cls = new RepositoryPackClass(dataTable);

            VBDocument document = new VBDocument(dataTable.TableName, projectName);
            VBNamespace ns = CreateNamespace(CreateNamespaceName(namespaceName, dataTable.TableName), GetUsingList(namespaceName, dataTable.TableName, projectName), cls);
            document.Namespaces.Add(ns);

            return document;
        }
 
        public VBDocument CreateDocument(DataSet dataset, string tableName, string nsName, string projectName)
        {
            var datatable = dataset.Tables[tableName];
            return Create(datatable, nsName, projectName);
        }

        public List<VBDocument> CreateDocuments(DataSet dataset, string namespaceName, string projectName)
        {
            var result = new List<VBDocument>();
            foreach (DataTable table in dataset.Tables)
            {
                if (table.Prefix.ToLower() == "v")
                    continue;
                var document = Create(table, namespaceName, projectName);
                result.Add(document);
            }
            return result;
        }
    }
}
