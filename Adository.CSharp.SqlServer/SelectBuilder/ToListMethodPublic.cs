using Adository.CSharp.SqlServer.Models;
using System.Data;

namespace Adository.CSharp.SqlServer.SelectBuilder
{
    public class ToListMethodPublic : CSMethod
    {
        private DataTable datatable;

        public ToListMethodPublic(DataTable datatable) : base($"List<{datatable.TableName}>", "ToList", CSMemberModifier.Public)
        {
            this.datatable = datatable;
            ConstructParameter();
            ConstructBody();
        }

        private void ConstructParameter()
        {
            this.MethodArgs.Add(new CSArgument("string", "sql"));
        }

        private void ConstructBody()
        {
            this.Statements.Add("return ToList(new SqlCommand(sql));");
        }
    }
}
