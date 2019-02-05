using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.DbContextBuilder
{
    /// <summary>
    /// DbContext(or Unit Of Work) class builder.
    /// </summary>
    public class DbClass : VBClass
    {
        private DataSet dataset;

        public DbClass(DataSet dataset, string className) : base(className, VBClassModifier.PublicPartial)
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

                    VBProperty viewProperty = new VBProperty(typeName, propName, VBMemberModifier.PublicOverridable);
                    this.Properties.Add(viewProperty);
                    continue;
                }

                typeName = $"{tableName}RepositoryPack";
                propName = $"{tableName}";
                VBProperty tableProperty = new VBProperty(typeName, propName, VBMemberModifier.PublicOverridable);

                this.Properties.Add(tableProperty);
            }
        }

        private void CreateConstructor()
        {
            string connectionStringName = $"{Quotes}{dataset.DataSetName}ConnectionString{Quotes}";
            string parameter = $"New ConnectionStringBuilder({connectionStringName})";
            var constructor = new VBClassConstructor(parameter);
            SetupConstructorStatements(constructor);

            this.Constructors.Add(constructor);
        }

        private void SetupConstructorStatements(VBClassConstructor constructor)
        {
            foreach (DataTable table in dataset.Tables)
            {
                string tableName = table.TableName;
                if (table.Prefix.ToLower() == "v")
                {
                    constructor.Statements.Add($"{tableName} = New {tableName}View(Me)");
                    continue;
                }
                constructor.Statements.Add($"{tableName} = New {tableName}RepositoryPack(Me)");
            }
        }
    }
}
