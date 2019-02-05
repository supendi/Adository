using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.DbContextBuilder
{
    /// <summary>
    /// DbContext(or Unit Of Work) class builder.
    /// </summary>
    public class DbClass : CSClass
    {
        private DataSet dataset;

        public DbClass(DataSet dataset, string className) : base(className, CSClassModifier.PublicPartial)
        {
            this.dataset = dataset;
            InheritsFrom = "SqlServerDbAccess";
            BuildClass();
        }

        private void BuildClass()
        {
            CreateProperties();
            CreateConstructor();
        }

        private void CreateProperties()
        {
            foreach (DataTable table in dataset.Tables)
            {
                string tableName = table.TableName;
                string typeName = string.Empty;
                string propName = string.Empty;

                //Detect if datatable is a 'View'
                if (table.Prefix.ToLower() == "v")
                {
                    typeName = $"{tableName}View";
                    propName = $"{tableName}";

                    CSProperty viewProperty = new CSProperty(typeName, propName, CSMemberModifier.PublicVirtual);
                    this.Properties.Add(viewProperty);
                    continue;
                }

                typeName = $"{tableName}RepositoryPack";
                propName = $"{tableName}";
                CSProperty tableProperty = new CSProperty(typeName, propName, CSMemberModifier.PublicVirtual);

                this.Properties.Add(tableProperty);
            }
        }

        private void CreateConstructor()
        {
            string parameter = $"new ConnectionStringBuilder({Quotes}{dataset.DataSetName}ConnectionString{Quotes})";
            var constructor = new CSClassConstructor(parameter);
            SetupConstructorStatements(constructor);

            this.Constructors.Add(constructor);
        }

        private void SetupConstructorStatements(CSClassConstructor constructor)
        {
            foreach (DataTable table in dataset.Tables)
            {
                string tableName = table.TableName;
                if (table.Prefix.ToLower() == "v")
                {
                    constructor.Statements.Add($"{tableName} = new {tableName}View(this);");
                    continue;
                }
                constructor.Statements.Add($"{tableName} = new {tableName}RepositoryPack(this);");
            }
        }
    }
}
