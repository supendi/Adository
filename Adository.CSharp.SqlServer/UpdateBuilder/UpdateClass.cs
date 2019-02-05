using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.UpdateBuilder
{
    public class UpdateClass : CSClass
    {
        private DataTable datatable;
        public UpdateClass(DataTable datatable) : base($"{datatable.TableName}Update", CSClassModifier.PublicPartial)
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
