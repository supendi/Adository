using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.UpdateBuilder
{
    public class UpdateClass : VBClass
    {
        private DataTable datatable;
        public UpdateClass(DataTable datatable) : base($"{datatable.TableName}Update", VBClassModifier.PublicPartial)
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
            this.Methods.Add(new SetSqlCommandParameterMethod(datatable));
            this.Methods.Add(new UpdateByPrimaryKeyMethod(datatable));

            CreateUpdateByColumnMethod();
            CreateUpdateColumnByPrimaryKey();
        }

        private void CreateUpdateByColumnMethod()
        {
            foreach (DataColumn clm in datatable.Columns)
            {
                this.Methods.Add(new UpdateByColumnMethod(datatable, clm));
            }
        }

        private void CreateUpdateColumnByPrimaryKey()
        {
            foreach (DataColumn clm in datatable.Columns)
            {
                bool skip = false;
                foreach (DataColumn key in datatable.PrimaryKey)
                {
                    if (clm == key)
                        skip = true;
                }

                if (datatable.PrimaryKey.Length <= 0)
                    skip = true;

                if (!skip)
                    this.Methods.Add(new UpdateColumnByPrimaryKeyMethod(datatable, clm));
            }
        }
    }
}
