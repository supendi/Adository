using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.RepositoryPackBuilder
{
    public class RepositoryPackClass : CSClass
    {
        public RepositoryPackClass(DataTable dataTable) : base($"{dataTable.TableName}RepositoryPack", CSClassModifier.PublicPartial)
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

            //var totalRecordBlock = new CSBlock("public int TotalRecords");
            //var getBlock = new CSBlock("get");
            //getBlock.Statements.Add("return Select.All().Count();");
            //totalRecordBlock.Statements.Add(getBlock.ToString());
            //this.Statements.Add(totalRecordBlock.ToString());

            CSProperty selectProp = new CSProperty($"{tableName}Query", "Query", CSMemberModifier.PublicVirtual);
            CSProperty insertProp = new CSProperty($"{tableName}Insert", "Insert", CSMemberModifier.PublicVirtual);
            CSProperty updateProp = new CSProperty($"{tableName}Update", "Update", CSMemberModifier.PublicVirtual);
            CSProperty deleteProp = new CSProperty($"{tableName}Delete", "Delete", CSMemberModifier.PublicVirtual);

            this.Properties.Add(selectProp);
            this.Properties.Add(insertProp);
            this.Properties.Add(updateProp);
            this.Properties.Add(deleteProp);
        }

        private void CreateConstructor(DataTable dataTable)
        {
            var constructor = new CSClassConstructor("dbAccess");
            constructor.Args.Add(new CSArgument("SqlServerDbAccess", "dbAccess"));

            this.Constructors.Add(constructor);
            constructor.Statements.Add($"Query = new {dataTable.TableName}Query(this);");
            constructor.Statements.Add($"Insert = new {dataTable.TableName}Insert(this);");
            constructor.Statements.Add($"Update = new {dataTable.TableName}Update(this);");
            constructor.Statements.Add($"Delete = new {dataTable.TableName}Delete(this);");
        }
    }
}
