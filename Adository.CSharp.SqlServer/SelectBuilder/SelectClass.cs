using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class SelectClass : CSClass
    {
        private DataTable datatable;
        public SelectClass(DataTable datatable) : base($"{datatable.TableName}Query", CSClassModifier.PublicPartial)
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
            this.Methods.Add(new ToListMethod(datatable));
            this.Methods.Add(new ToListMethodPublic(datatable));
            this.Methods.Add(new CountMethod(datatable));
            this.Methods.Add(new CountByKeywordMethod(datatable));
            this.Methods.Add(new SelectAllMethod(datatable));
            this.Methods.Add(new SelectByKeywordKeyMethod(datatable));
            if (datatable.PrimaryKey.Length > 0)
                this.Methods.Add(new SelectByPrimaryKeyMethod(datatable));
            CreateSelectByColumnMethod();
        }

        private void CreateSelectByColumnMethod()
        {
            foreach (DataColumn clm in datatable.Columns)
            {
                this.Methods.Add(new SelectByColumnMethod(datatable, clm));
            }
        }
    }
}
