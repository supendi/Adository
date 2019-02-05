using Adository.VB.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectDocumentProvider : DocumentProviderBase<SelectClass>
    {
        string suffix = "Repository";

        public SelectDocumentProvider()
        {
        }

        protected string[] GetUsingList()
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                "System",
                "System.Collections.Generic",
                "System.Data",
                "System.Data.SqlClient"
            };
        }

        private string CreateNamespaceName(string namespaceName, string tableName)
        {
            return $"{namespaceName}.{tableName}{suffix}";
        }

        private VBDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            namespaceName = CreateNamespaceName(namespaceName, dataTable.TableName);
            SelectClass cls = new SelectClass(dataTable);

            VBDocument document = new VBDocument(dataTable.TableName, projectName);
            VBNamespace ns = CreateNamespace(namespaceName, GetUsingList(), cls);
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
                var document = Create(table, namespaceName, projectName);
                result.Add(document);
            }
            return result;
        }
    }
}
