using Adository.CSharp.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.CSharp.SqlServer.ModelBuilder
{
    public class ModelDocumentProvider
    {
        public ModelDocumentProvider()
        {
        }

        private CSDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            CSNamespace ns = new CSNamespace(namespaceName);
            CSDocument document = new CSDocument(dataTable.TableName, projectName);

            ns.Classes.Add(new ModelClass(dataTable));
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
