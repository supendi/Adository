using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class SelectClass : VBClass
    {
        private DataTable datatable;
        public SelectClass(DataTable datatable) : base($"{datatable.TableName}Query", VBClassModifier.PublicPartial)
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
