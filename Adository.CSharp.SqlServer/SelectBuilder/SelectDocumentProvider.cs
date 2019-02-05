using Adository.CSharp.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
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

        private CSDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            namespaceName = CreateNamespaceName(namespaceName, dataTable.TableName);
            SelectClass cls = new SelectClass(dataTable);

            CSDocument document = new CSDocument(dataTable.TableName, projectName);
            CSNamespace ns = CreateNamespace(namespaceName, GetUsingList(), cls);
            document.Namespaces.Add(ns);

            return document;
        }

        public CSDocument CreateDocument(DataSet dataset, string tableName, string nsName, string projectName)
        {
            var datatable = dataset.Tables[tableName];
            return Create(datatable, nsName, projectName);
        }

        public List<CSDocument> CreateDocuments(DataSet dataset, string namespaceName, string projectName)
        {
            var result = new List<CSDocument>();
            foreach (DataTable table in dataset.Tables)
            {
                var document = Create(table, namespaceName, projectName);
                result.Add(document);
            }
            return result;
        }
    }
}
