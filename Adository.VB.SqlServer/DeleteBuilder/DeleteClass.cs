using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.DeleteBuilder
{
    public class DeleteClass : VBClass
    {
        private DataTable datatable;

        public DeleteClass(DataTable datatable) : base($"{datatable.TableName}Delete", VBClassModifier.PublicPartial)
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
            var constructor = new VBClassConstructor();
            constructor.Args.Add(new VBArgument($"SqlServerTable", $"table"));
            constructor.Statements.Add($"Me.table = table");
            this.Constructors.Add(constructor);
        }

        private void CreateFields()
        {
            this.Fields.Add(new VBField($"SqlServerTable", $"table"));
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
