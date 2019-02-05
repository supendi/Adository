using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.RepositoryPackBuilder
{
    public class RepositoryPackClass : VBClass
    {
        public RepositoryPackClass(DataTable dataTable) : base($"{dataTable.TableName}RepositoryPack", VBClassModifier.PublicPartial)
        {
            InheritsFrom = "SqlServerTable";
            Build(dataTable);
        }

        private void Build(DataTable dataTable)
        {
            CreateProperties(dataTable);
            CreateConstructor(dataTable);
        }

        private void CreateProperties(DataTable dataTable)
        {
            var tableName = dataTable.TableName; 

            VBProperty selectProp = new VBProperty($"{tableName}Query", "Query", VBMemberModifier.PublicOverridable);
            VBProperty insertProp = new VBProperty($"{tableName}Insert", "Insert", VBMemberModifier.PublicOverridable);
            VBProperty updateProp = new VBProperty($"{tableName}Update", "Update", VBMemberModifier.PublicOverridable);
            VBProperty deleteProp = new VBProperty($"{tableName}Delete", "Delete", VBMemberModifier.PublicOverridable);

            this.Properties.Add(selectProp);
            this.Properties.Add(insertProp);
            this.Properties.Add(updateProp);
            this.Properties.Add(deleteProp);
        }

        private void CreateConstructor(DataTable dataTable)
        {
            var constructor = new VBClassConstructor("dbAccess");
            constructor.Args.Add(new VBArgument("SqlServerDbAccess", "dbAccess"));

            this.Constructors.Add(constructor);
            constructor.Statements.Add($"Query = New {dataTable.TableName}Query(Me)");
            constructor.Statements.Add($"Insert = New {dataTable.TableName}Insert(Me)");
            constructor.Statements.Add($"Update = New {dataTable.TableName}Update(Me)");
            constructor.Statements.Add($"Delete = New {dataTable.TableName}Delete(Me)");
        }
    }
}
