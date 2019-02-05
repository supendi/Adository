using Adository.CSharp.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class UpdateDocumentProvider : DocumentProviderBase<UpdateClass>
    {
        private string suffix = "Repository";

        public UpdateDocumentProvider()
        {
        }


        protected string[] GetUsingList()
        {
            return new string[]
            {
                $"Adository.Data.SqlServer",
                "System",
                "System.Data.SqlClient"
            };
        }

        private string CreateNamespaceName(string namespaceName, string tableName)
        {
            return $"{namespaceName}.{tableName}{suffix}";
        }

        private CSDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            UpdateClass cls = new UpdateClass(dataTable);

            CSDocument document = new CSDocument(dataTable.TableName, projectName);
            CSNamespace ns = CreateNamespace(CreateNamespaceName(namespaceName, dataTable.TableName), GetUsingList(), cls);
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
                    continue;
                var document = Create(table, namespaceName, projectName);
                result.Add(document);
            }
            return result;
        }
    }
}
