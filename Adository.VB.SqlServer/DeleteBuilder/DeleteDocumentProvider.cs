using Adository.VB.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.VB.SqlServer.DeleteBuilder
{
    public class DeleteDocumentProvider : DocumentProviderBase<DeleteClass>
    {
        string suffix = "Repository";

        public DeleteDocumentProvider()
        {
        }

        protected string[] GetUsingList()
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                $"System",
                $"System.Data.SqlClient"
            };
        }

        private string CreateNamespaceName(string defaultNamespaceName, string tableName)
        {
            return $"{defaultNamespaceName}.{tableName}{suffix}";
        }

        private VBDocument Create(DataTable dataTable, string defaultNamespaceName, string projectName)
        { 
            DeleteClass cls = new DeleteClass(dataTable);

            VBDocument document = new VBDocument(dataTable.TableName, projectName);
            VBNamespace ns = CreateNamespace(CreateNamespaceName(defaultNamespaceName, dataTable.TableName), GetUsingList(), cls);
            document.Namespaces.Add(ns);

            return document;
        }

        public VBDocument Create(DataSet dataset, string tableName, string nsName, string projectName)
        {
            var datatable = dataset.Tables[tableName];
            return Create(datatable, nsName, projectName);
        }

        public List<VBDocument> Create(DataSet dataset, string namespaceName, string projectName)
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
