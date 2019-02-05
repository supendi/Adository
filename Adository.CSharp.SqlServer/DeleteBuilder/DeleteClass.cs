using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.DeleteBuilder
{
    public class DeleteClass : CSClass
    {
        private DataTable datatable;

        public DeleteClass(DataTable datatable) : base($"{datatable.TableName}Delete", CSClassModifier.PublicPartial)
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
            this.Methods.Add(new DeleteByPrimaryKeyMethod(datatable));
            CreateDeleteByColumnMethod();
        }

        private void CreateDeleteByColumnMethod()
        {
            foreach (DataColumn clm in datatable.Columns)
            {
                this.Methods.Add(new DeleteByColumnMethod(datatable, clm));
            }
        }
    }
}
