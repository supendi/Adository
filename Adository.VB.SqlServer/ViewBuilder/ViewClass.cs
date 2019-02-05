using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.ViewBuilder
{
    public class ViewClass : VBClass
    {
        public ViewClass(DataTable dataTable) : base($"{dataTable.TableName}View", VBClassModifier.PublicPartial)
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

            this.Properties.Add(selectProp);
        }

        private void CreateConstructor(DataTable dataTable)
        {
            var constructor = new VBClassConstructor("dbAccess");
            constructor.Args.Add(new VBArgument("SqlServerDbAccess", "dbAccess"));

            this.Constructors.Add(constructor);
            constructor.Statements.Add($"Query = new {dataTable.TableName}Query(Me)");
        }
    }
}
