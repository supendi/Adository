using Adository.VB.SqlServer.Models;
using System.Collections.Generic;
using System.Data;

namespace Adository.VB.SqlServer.ModelBuilder
{
    public class ModelDocumentProvider
    {
        public ModelDocumentProvider()
        {
        }

        private VBDocument Create(DataTable dataTable, string namespaceName, string projectName)
        {
            VBNamespace ns = new VBNamespace(namespaceName);
            VBDocument document = new VBDocument(dataTable.TableName, projectName);

            ns.Classes.Add(new ModelClass(dataTable));
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
