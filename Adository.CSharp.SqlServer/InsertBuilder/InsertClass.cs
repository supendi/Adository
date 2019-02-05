using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.InsertBuilder
{
    public class InsertClass : CSClass
    {
        private DataTable datatable;
        public InsertClass(DataTable datatable) : base($"{datatable.TableName}Insert", CSClassModifier.PublicPartial)
        {
            this.datatable = datatable;
            Build();
        }

        private void Build()
        {
            CreateFields();
            CreateConstructor();
            CreateMethods();
        }

        private void CreateConstructor()
        {
            var constructor = new CSClassConstructor();
            constructor.Args.Add(new CSArgument($"SqlServerTable", $"table"));
            constructor.Statements.Add($"this.table = table;");
            this.Constructors.Add(constructor);
        }

        private void CreateFields()
        {
            this.Fields.Add(new CSField($"SqlServerTable", $"table"));
        }

        private void CreateMethods()
        {
            this.Methods.Add(new InsertNewRecordMethod(datatable));
        }
    }
}
