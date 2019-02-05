using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.ViewBuilder
{
    public class ViewClass : CSClass
    {
        public ViewClass(DataTable dataTable) : base($"{dataTable.TableName}View", CSClassModifier.PublicPartial)
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
            CSProperty selectProp = new CSProperty($"{tableName}Query", "Query", CSMemberModifier.PublicVirtual);

            this.Properties.Add(selectProp);
        }

        private void CreateConstructor(DataTable dataTable)
        {
            var constructor = new CSClassConstructor("dbAccess");
            constructor.Args.Add(new CSArgument("SqlServerDbAccess", "dbAccess"));

            this.Constructors.Add(constructor);
            constructor.Statements.Add($"Query = new {dataTable.TableName}Query(this);");
        }
    }
}
