using Adository.Common;
using Adository.CSharp.SqlServer.DbContextBuilder;
using Adository.CSharp.SqlServer.DeleteBuilder;
using Adository.CSharp.SqlServer.InsertBuilder;
using Adository.CSharp.SqlServer.ModelBuilder;
using Adository.CSharp.SqlServer.RepositoryPackBuilder;
using Adository.CSharp.SqlServer.SelectBuilder;
using Adository.CSharp.SqlServer.UpdateBuilder;
using Adository.CSharp.SqlServer.ViewBuilder;
using System;
using System.Data;
using System.IO;

namespace Adository.CSharp
{
    /// <summary>
    /// The generator class
    /// </summary>
    public class AdositoryGenerator : IDisposable
    {
        public DbServerManager ServerManager { get; set; }
        public ModelDocumentProvider ModelProvider { get; set; }
        public SelectDocumentProvider SelectProvider { get; set; }
        public InsertDocumentProvider InsertProvider { get; set; }
        public UpdateDocumentProvider UpdateProvider { get; set; }
        public DeleteDocumentProvider DeleteProvider { get; set; }
        public RepositoryPackDocumentProvider RepositoryPackProvider { get; set; }
        public ViewDocumentProvider ViewProvider { get; set; }
        public DbDocumentProvider DbProvider { get; set; }

        public AdositoryGenerator(DbServerManager dbServerManager)
        {
            ServerManager = dbServerManager;

            ModelProvider = new ModelDocumentProvider();
            SelectProvider = new SelectDocumentProvider();
            InsertProvider = new InsertDocumentProvider();
            UpdateProvider = new UpdateDocumentProvider();
            DeleteProvider = new DeleteDocumentProvider();
            RepositoryPackProvider = new RepositoryPackDocumentProvider();
            ViewProvider = new ViewDocumentProvider();
            DbProvider = new DbDocumentProvider();
        }

        private void CreateDirectories(DataSet dataset, string projectFolder)
        {
            if (dataset.Tables.Count > 0)
                Directory.CreateDirectory($@"{projectFolder}\RepositoryPacks");

            foreach (DataTable table in dataset.Tables)
            {
                var folder = $"{table.TableName}Repository";

                var path = $@"{projectFolder}\{folder}";
                Directory.CreateDirectory(path);
            }
        }

        public void SaveModels(DataSet dataset, string folder, string namespaceName, string projectName)
        {
            var documents = ModelProvider.CreateDocuments(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}.cs";
                var path = $@"{folder}\{filename}";

                document.Save(path);
            }
        }

        public string PreviewModelSourceCode(string dbName, string tableName, string nsName, string projectName)
        {
            var dataset = ServerManager.GetDataSet(dbName);
            return ModelProvider.CreateDocument(dataset, tableName, nsName, projectName).GetSourceCode();
        }

        private void SaveSelectClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = SelectProvider.CreateDocuments(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}Query.cs";
                var folder = $"{document.Name}Repository";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveInsertClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = InsertProvider.Create(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}Insert.cs";
                var folder = $"{document.Name}Repository";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveUpdateClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = UpdateProvider.CreateDocuments(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}Update.cs";
                var folder = $"{document.Name}Repository";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveDeleteClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = DeleteProvider.Create(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}Delete.cs";
                var folder = $"{document.Name}Repository";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveTableClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = RepositoryPackProvider.CreateDocuments(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}RepositoryPack.cs";
                var folder = $"RepositoryPacks";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveViewClass(DataSet dataset, string projectFolder, string namespaceName, string projectName)
        {
            var documents = ViewProvider.CreateDocuments(dataset, namespaceName, projectName);

            foreach (var document in documents)
            {
                var filename = $"{document.Name}View.cs";
                var folder = $"RepositoryPacks";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveDbClass(DataSet dataset, string projectFolder, string namespaceName, string projectName, string dbContextName)
        {
            var document = DbProvider.Create(dataset, dbContextName, namespaceName, projectName);

            var path = $@"{projectFolder}\{dbContextName}.cs";
            document.Save(path);
        }

        public void SaveAll(string dbName, string projectFolder, string namespaceName, string projectName, string dbContextName)
        {
            var dataset = ServerManager.GetDataSet(dbName);

            CreateDirectories(dataset, projectFolder);

            SaveModels(dataset, projectFolder, namespaceName, projectName);
            SaveSelectClass(dataset, projectFolder, namespaceName, projectName);
            SaveInsertClass(dataset, projectFolder, namespaceName, projectName);
            SaveUpdateClass(dataset, projectFolder, namespaceName, projectName);
            SaveDeleteClass(dataset, projectFolder, namespaceName, projectName);
            SaveTableClass(dataset, projectFolder, namespaceName, projectName);
            SaveViewClass(dataset, projectFolder, namespaceName, projectName);
            SaveDbClass(dataset, projectFolder, namespaceName, projectName, dbContextName);
        }

        public void Dispose()
        {
            ServerManager.Dispose();
        }
    }
}
