using Adository.Common;
using Adository.VB.SqlServer.DbContextBuilder;
using Adository.VB.SqlServer.DeleteBuilder;
using Adository.VB.SqlServer.InsertBuilder;
using Adository.VB.SqlServer.ModelBuilder;
using Adository.VB.SqlServer.RepositoryPackBuilder;
using Adository.VB.SqlServer.SelectBuilder;
using Adository.VB.SqlServer.UpdateBuilder;
using Adository.VB.SqlServer.ViewBuilder;
using System;
using System.Data;
using System.IO;

namespace Adository.VB
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
                var filename = $"{document.Name}.vb";
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
                var filename = $"{document.Name}Query.vb";
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
                var filename = $"{document.Name}Insert.vb";
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
                var filename = $"{document.Name}Update.vb";
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
                var filename = $"{document.Name}Delete.vb";
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
                var filename = $"{document.Name}RepositoryPack.vb";
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
                var filename = $"{document.Name}View.vb";
                var folder = $"RepositoryPacks";
                var path = $@"{projectFolder}\{folder}\{filename}";

                document.Save(path);
            }
        }

        private void SaveDbClass(DataSet dataset, string projectFolder, string namespaceName, string projectName, string dbContextName)
        {
            var document = DbProvider.Create(dataset, dbContextName, namespaceName, projectName);

            var path = $@"{projectFolder}\{dbContextName}.vb";
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
