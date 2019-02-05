using Adository.VB.SqlServer.Models;
using System.Data;

namespace Adository.VB.SqlServer.SelectBuilder
{
    public class ToListMethodPublic : VBMethod
    {
        private DataTable datatable;

        public ToListMethodPublic(DataTable datatable) : base($"List(Of {datatable.TableName})", "ToList", MethodType.Function, VBMemberModifier.Public)
        {
            this.datatable = datatable;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            this.MethodArgs.Add(new VBArgument("String", "sql"));
        }

        private void ConstructBody()
        {
            this.Statements.Add("Return ToList(New SqlCommand(sql))");
        }
    }
}
