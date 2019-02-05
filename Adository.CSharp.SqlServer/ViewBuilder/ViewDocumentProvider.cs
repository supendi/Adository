using Adository.CSharp.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.CSharp.SqlServer.ViewBuilder
{
    public class ViewDocumentProvider : DocumentProviderBase<ViewClass>
    {
        string suffix = "Repository";

        public ViewDocumentProvider()
        {
        }


        protected string[] GetUsingList(string namespaceName, string tableName)
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                "System",
                "System.Data.SqlClient",
                $"{namespaceName}.{tableName}Repository"
            };
        }

        private string CreateNamespaceName(string namespaceName, string tableName)
        {
            return $"{namespaceName}.RepositoryPacks";
        }

        private CSDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            ViewClass cls = new ViewClass(dataTable);

            CSDocument document = new CSDocument(dataTable.TableName, projectName);
            CSNamespace ns = CreateNamespace(CreateNamespaceName(namespaceName, dataTable.TableName), GetUsingList(namespaceName, dataTable.TableName), cls);
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
                if (table.Prefix.ToLower() == "v")
                {
                    var document = Create(table, namespaceName, projectName);
                    result.Add(document);
                }
            }
            return result;
        }
    }
}
